using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTerestrialAttack : MonoBehaviour
{
    [SerializeField] private EnemyStatsManager EnemyStatsManager;
    private EnemyTerestrialStats EnemyTerestrialStats;
    private Transform Player;
    private PlayerStats playerStats;
    private PlayerDataManager PlayerDataManager;
    private float lastAttackTime = 0f;

    private Slider HealthBar;
    
    
    
    
    
    private void Start()
    {
        EnemyTerestrialStats = EnemyStatsManager.EnemyTerestrialStats;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = FindFirstObjectByType<PlayerStatsManager>().GetComponent<PlayerStatsManager>().PlayerStats;
        PlayerDataManager = FindAnyObjectByType<PlayerDataManager>();
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
        FindFirstObjectByType<AudioManager>().TriggerSwordSounds();
        
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
        TeleportDeath();
        Player.GetComponent<AnimationHandler>().TrigerDeathAnimation();
    }

    private void TeleportDeath()
    {
        List<int> savedPos = PlayerDataManager.PlayerData.Location;
        Vector3 position = new Vector3(savedPos[0], savedPos[1], savedPos[2]);
        Player.GetComponent<CharacterController>().enabled = false;
        Player.position = position;
        Player.GetComponent<CharacterController>().enabled = true;
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