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

    [SerializeField] private Canvas EnemyCanvas; 
    private Transform EnemyCanvasTransform;
    private GameObject EnemyCanvasGameObject;
    [SerializeField] private Slider HealthBar;


    
    
    
    private void Start()
    {
        EnemyMarineStats = EnemyStatsManager.EnemyMarineStats;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerStatsManager playerStatsManager = FindFirstObjectByType<PlayerStatsManager>();
        BoatStats = playerStatsManager.BoatStats;
        PlayerDataManager = playerStatsManager.PlayerDataManager;

        EnemyCanvasTransform = EnemyCanvas.transform;
        EnemyCanvasGameObject = EnemyCanvas.gameObject;
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
        CharacterController characterController = Player.GetComponent<CharacterController>();
        characterController.enabled = false;
        Player.position = position;
        characterController.enabled = true;
    }

    
    
    
    
    private void UpdateHealthBar()
    {
        float distance = Vector3.Distance(Player.position, transform.position);
        if (distance > 50f)
        {
            if (EnemyCanvasGameObject.activeInHierarchy) EnemyCanvasGameObject.SetActive(false);
            return;
        }
        if (!EnemyCanvasGameObject.activeInHierarchy) EnemyCanvasGameObject.SetActive(true);
        HealthBar.value = EnemyMarineStats.HP;
        
        EnemyCanvasTransform.LookAt(Player);
        
        if (distance <= 10f)
        {
            Vector3 directon = Player.position - transform.position;
            directon.y = 0f;
            transform.rotation = Quaternion.LookRotation(directon);
        }
        
        EnemyCanvasTransform.rotation = Quaternion.Euler(0, EnemyCanvasTransform.rotation.eulerAngles.y + 180, 0);
    }
}