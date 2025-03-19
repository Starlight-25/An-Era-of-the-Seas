using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{
    private PlayerStatsManager PlayerStatsManager;
    private TextMeshProUGUI DmgText;
    private float lastAttackTime = 0f;

    
    
    
    
    private void Start()
    {
        PlayerStatsManager = FindFirstObjectByType<PlayerStatsManager>().GetComponent<PlayerStatsManager>();
        DmgText = transform.Find("Interactor Text").Find("DmgText").GetComponent<TextMeshProUGUI>();
    }

    
    
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + 0.5f)
        {
            Attack();
            lastAttackTime = Time.time;
        }
        else if (Time.time >= lastAttackTime + 0.5f)
        {
            DmgText.text = "";
        }
    }


    
    
    
    private void Attack()
    {
        transform.GetComponent<AnimationHandler>().TriggerAttackAnimation();
        FindFirstObjectByType<AudioManager>().TriggerSwordSounds();
            
        PlayerStats playerStats = PlayerStatsManager.PlayerStats;
        int critrate = Random.Range(0, 101) <= playerStats.CritRate ? 1 : 0;
        int dmg = Mathf.RoundToInt(playerStats.ATK * (1 + critrate * (playerStats.CritDMG / 100f)));
        Transform target = GetEnemy();
        if (target != null)
        {
            DmgText.text = dmg.ToString();
            DMGOnEnemy(target, dmg);
        }
    }

    private Transform GetEnemy()
    {
        Transform playerCamera = transform.Find("Camera");
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                return hit.collider.transform;
            }
        }
        return null;
    }

    private void DMGOnEnemy(Transform enemy, int dmg)
    {
        EnemyTerestrialStats enemmEnemyTerestrialStats = enemy.GetComponent<EnemyStatsManager>().EnemyTerestrialStats;
        enemmEnemyTerestrialStats.HP -= dmg;
        if (enemmEnemyTerestrialStats.HP <= 0) DeathEnemy(enemy);
    }

    private void DeathEnemy(Transform enemy)
    {
        EnemyTerestrialStats enemyTerestrialStats = enemy.GetComponent<EnemyStatsManager>().EnemyTerestrialStats;
        PlayerStatsManager.AddMaterial(enemyTerestrialStats.CoinsDrop, enemyTerestrialStats.PWDDrop, 0, 0);
        Debug.Log(enemyTerestrialStats.CoinsDrop + "    " + enemyTerestrialStats.PWDDrop + "    " + enemyTerestrialStats.SwordRarityDrop);
        if (enemyTerestrialStats.SwordRarityDrop != "0") PlayerStatsManager.AddItem(GetRandomWeapon(enemyTerestrialStats.SwordRarityDrop));

        enemy.GetComponent<EnemyAnimation>().TriggerDeathAnimation();
        Destroy(enemy.gameObject, 1f);
    }

    private Weapon GetRandomWeapon(string rarity)
    {
        List<WeaponJSON> weaponlist = new List<WeaponJSON>();
        List<WeaponJSON> weaponJsonList = PlayerStatsManager.JsonData.WeaponJSON;
        foreach (WeaponJSON weaponJson in weaponJsonList)
        {
            if (weaponJson.Rarity == rarity) weaponlist.Add(weaponJson);
        }

        WeaponJSON selectedWeapon = weaponlist[Random.Range(0, weaponlist.Count)];
        Weapon weapon = new Weapon()
        {
            Level = 1,
            Name = selectedWeapon.Name,
            Rarity = rarity
        };

        return weapon;
    }
}