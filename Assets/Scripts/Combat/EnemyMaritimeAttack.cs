using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMaritimeAttack : MonoBehaviour
{
    [SerializeField] private EnemyStatsManager EnemyStatsManager;
    private EnemyMarineStats EnemyMarineStats;
    private Transform Player;
    private BoatStats BoatStats;
    private PlayerDataManager PlayerDataManager;
    private float lastAttackTime;

    private Slider HealthBar;


    
    
    
    private void Start()
    {
        EnemyMarineStats = EnemyStatsManager.EnemyMarineStats;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        BoatStats = FindFirstObjectByType<PlayerStatsManager>().BoatStats;
        PlayerDataManager = FindFirstObjectByType<PlayerDataManager>();
        HealthBar = transform.Find("EnemyCanvas").Find("HealthBar").GetComponent<Slider>();
        HealthBar.transform.Find("LvlText").GetComponent<TextMeshProUGUI>().text = $"Lvl {EnemyMarineStats.Level}";
        HealthBar.maxValue = EnemyMarineStats.MaxHP;
    }


    
    
    
    private void Update()
    {
        float distancePlayer = Vector3.Distance(transform.position, Player.position);

        if (distancePlayer <= 10f && Time.time >= lastAttackTime + 1f && EnemyMarineStats.HP > 0)
        {
            AttackPlayer();
            lastAttackTime = Time.time;
        }
        UpdateHealthBar();
    }



    
    
    private void AttackPlayer()
    {
        if (BoatStats.DEF > 0)
        {
            BoatStats.DEF -= EnemyMarineStats.ATK;
            if (BoatStats.DEF < 0)
            {
                BoatStats.HP -= -BoatStats.DEF;
                BoatStats.DEF = 0;
            }
        }
        else BoatStats.HP -= EnemyMarineStats.ATK;
        
        if (BoatStats.HP <= 0) DeathPlayer();
        Debug.Log(BoatStats.HP + " " + BoatStats.DEF);
    }
    
    
    
    
    
    private void DeathPlayer()
    {
        BoatStats.DEF = BoatStats.MaxDEF;
        BoatStats.HP = BoatStats.MaxHP;
        TeleportDeath();
        Player.GetComponent<AnimationHandler>().TrigerDeathAnimation();
    }
    
    
    
    
    
    private void TeleportDeath()
    {
        List<int> savedPos = PlayerDataManager.PlayerData.Location;
        Vector3 position = new Vector3(savedPos[0], savedPos[1], savedPos[2]);
        BoatState boatState = Player.GetComponent<BoatInitHandler>().BoatState;
        if (boatState.inBoat) // the player is in the boat
        {
            if (boatState.inHelm) HelmInteractor.SwitchCameras(); // the player is in helm mode
            Player.GetComponent<InteractorHandler>().ExitBoat(FindAnyObjectByType<BoatMovement>().transform);
            FindFirstObjectByType<PlayerUIManager>().BoatButtonClicked();
        }
        Player.GetComponent<CharacterController>().enabled = false;
        Player.position = position;
        Player.GetComponent<CharacterController>().enabled = true;
    }

    
    
    
    
    private void UpdateHealthBar()
    {
        HealthBar.value = EnemyMarineStats.HP;

        Transform playerCamera = Player.Find("Camera");
        Transform enemyCanvas = HealthBar.transform.parent;
        enemyCanvas.LookAt(playerCamera);
        
        if (Vector3.Distance(Player.position, transform.position) <= 10f)
        {
            Vector3 directon = playerCamera.position - transform.position;
            directon.y = 0f;
            transform.rotation = Quaternion.LookRotation(directon);
        }
        
        enemyCanvas.rotation = Quaternion.Euler(0, enemyCanvas.rotation.eulerAngles.y + 180, 0);
    }
}