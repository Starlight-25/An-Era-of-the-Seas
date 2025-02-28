using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    private EnemyTerestrialStats EnemyTerestrialStats;
    private Transform Player;
    private PlayerStats playerStats;
    private float lastAttackTime = 0f;

    private Slider HealthBar;
    
    
    
    
    
    private void Start()
    {
        EnemyTerestrialStats = transform.GetComponent<EnemyStatsManager>().EnemyTerestrialStats;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = FindFirstObjectByType<PlayerStatsManager>().GetComponent<PlayerStatsManager>().PlayerStats;
        HealthBar = transform.Find("EnemyCanvas").Find("HealthBar").GetComponent<Slider>();
        HealthBar.transform.Find("LvlText").GetComponent<TextMeshProUGUI>().text = $"Lvl {EnemyTerestrialStats.Level}";
        HealthBar.maxValue = EnemyTerestrialStats.MaxHP;
    }

    
    
    
    
    private void Update()
    {
        float distancePlayer = Vector3.Distance(transform.position, Player.position);

        if (distancePlayer <= 3f && Time.time >= lastAttackTime + 1f && EnemyTerestrialStats.HP > 0)
        {
            AttackPlayer();
            lastAttackTime = Time.time;
        }
        UpdateHealthBar();
    }

    
    
    
    
    private void AttackPlayer()
    {
        transform.GetComponent<EnemyAnimation>().TriggerAttackAnimation();
        
        if (playerStats.DEF > 0)
        {
            playerStats.DEF -= EnemyTerestrialStats.ATK;
            if (playerStats.DEF < 0)
            {
                playerStats.HP -= -playerStats.DEF;
                playerStats.DEF = 0;
            }
        }
        else playerStats.HP -= EnemyTerestrialStats.ATK;
        
        if (playerStats.HP <= 0) DeathPlayer();
    }

    private void DeathPlayer()
    {
        playerStats.DEF = playerStats.MaxDEF;
        playerStats.HP = playerStats.MaxHP;
        //teleport
        Player.GetComponent<AnimationHandler>().TrigerDeathAnimation();
    }

    private void UpdateHealthBar()
    {
        HealthBar.value = EnemyTerestrialStats.HP;

        Transform playerCamera = Player.Find("Camera");
        Transform enemyCanvas = HealthBar.transform.parent;
        enemyCanvas.LookAt(playerCamera);
        enemyCanvas.rotation = Quaternion.Euler(0, enemyCanvas.rotation.eulerAngles.y + 180, 0);
    }
    
}