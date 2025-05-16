using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class BoatAttack : MonoBehaviour
{
    private PlayerStatsManager PlayerStatsManager;
    [SerializeField] private TextMeshProUGUI DmgText;
    private float lastAttackTime;
    [SerializeField] private Transform PlayerCamera;

    
    
    

    private void Start()
    {
        PlayerStatsManager = FindFirstObjectByType<PlayerStatsManager>();
    }


    
    
    
    private void Update()
    {
        if (transform.GetComponent<BoatState>().inBoat)
        {
            if (Input.GetMouseButton(0) && Time.time >= lastAttackTime + 0.5f)
            {
                Attack();
                lastAttackTime = Time.time;
            }
            else if (Time.time >= lastAttackTime + 0.5f)
            {
                DmgText.text = "";
            }
        }
    }



    

    private void Attack()
    {
        BoatStats boatStats = PlayerStatsManager.BoatStats;
        int critrate = Random.Range(0, 101) <= boatStats.CritRate ? 1 : 0;
        int dmg = Mathf.RoundToInt(boatStats.ATK * (1 + critrate * (boatStats.CritDMG / 100f)));
        Transform target = GetEnemy();
        if (target != null)
        {
            DmgText.text = dmg.ToString();
            DMGOnEnemy(target, dmg);
        }
    }
    
    private Transform GetEnemy()
    {
        BoatState boatState = transform.GetComponent<BoatState>();
        Transform camera = boatState.inHelm ? transform.Find("HelmCamera") : PlayerCamera;
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, 10f, LayerMask.GetMask("Default")))
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.CompareTag("Enemy"))
            {
                return hit.collider.transform;
            }
        }
        return null;
    }

    
    
    
    
    private void DMGOnEnemy(Transform enemy, int dmg)
    {
        EnemyMarineStats enemyMarineStats = enemy.GetComponent<EnemyStatsManager>().EnemyMarineStats;
        enemyMarineStats.HP -= dmg;
        if (enemyMarineStats.HP <= 0) DeathEnemy(enemy);
    }
    
    
    
    
    
    private void DeathEnemy(Transform enemy)
    {
        EnemyMarineStats enemyMarineStats = enemy.GetComponent<EnemyStatsManager>().EnemyMarineStats;
        PlayerStatsManager.UpdateMaterial(enemyMarineStats.CoinsDrop, enemyMarineStats.PWDDrop);
        if (enemyMarineStats.SwordRarityDrop != "0")
        {
            Weapon weapon = GetRandomWeapon(enemyMarineStats.SwordRarityDrop);
            PlayerStatsManager.AddItem(weapon);
            DmgText.text = $"+ {weapon.Name}\n";
        }
        
        Destroy(enemy.gameObject);
        DmgText.text += $"+ {enemyMarineStats.CoinsDrop} Coins\n+ {enemyMarineStats.PWDDrop}";
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