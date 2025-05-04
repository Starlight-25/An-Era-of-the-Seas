using System;
using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    [SerializeField] private Slider HungerBar;
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    private float lastTimeHunger;
    private float DeltaHunger = 30f;
    private float lastTimeDmg;
    private float DeltaDamage = 1f;
    private float lastTimeRegen;
    private float DeltaRegen = 1f;





    private void Start()
    {
        lastTimeHunger = Time.time;
        lastTimeDmg = Time.time;
    }


    
    
    
    private void Update()
    {
        float curTime = Time.time;
        if (HungerBar.value > 0 && lastTimeHunger + DeltaHunger < curTime)
        {
            lastTimeHunger = curTime;
            HungerBar.value--;
        }

        if (HungerBar.value == 0 && lastTimeDmg + DeltaDamage < curTime)
        {
            lastTimeDmg = curTime;
            DamageHunger();
        }

        if (HungerBar.value == HungerBar.maxValue && lastTimeRegen + DeltaRegen < curTime)
        {
            lastTimeRegen = curTime;
            RegenerateHP();
        }
        if (Input.GetKeyDown(KeyCode.R)) Eat();
    }





    private void DamageHunger()
    {
        PlayerStats playerStats = PlayerStatsManager.PlayerStats;
        playerStats.HP -= playerStats.MaxHP / 100;
        if (playerStats.HP <= 0) DeathPlayer();
    }
    
    private void DeathPlayer()
    {
        PlayerStats playerStats = PlayerStatsManager.PlayerStats;
        playerStats.DEF = playerStats.MaxDEF;
        playerStats.HP = playerStats.MaxHP;
        //teleport
        //Player.GetComponent<AnimationHandler>().TrigerDeathAnimation();
    }
    
    
    
    
    
    public void Eat()
    {
        lastTimeHunger = Time.time;
        if (PlayerStatsManager.PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Fish <= 0 &&
            HungerBar.value >= HungerBar.maxValue) return;
        HungerBar.value++;
        PlayerStatsManager.UpdateFish(-1);
    }


    
    

    private void RegenerateHP()
    {
        PlayerStats playerStats = PlayerStatsManager.PlayerStats;
        playerStats.HP += playerStats.MaxHP / 100;
        if (playerStats.HP > playerStats.MaxHP) playerStats.HP = playerStats.MaxHP;
    }
}