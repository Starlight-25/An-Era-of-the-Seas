using System;
using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    [SerializeField] private Slider HungerBar;
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    private float lastTimeHunger;
    private float DeltaHunger = 45f;
    private float lastTimeDmg;
    private float DeltaDamage = 1f;





    private void Start()
    {
        lastTimeHunger = Time.time;
        lastTimeDmg = Time.time;
    }


    
    
    
    private void Update()
    {
        if (lastTimeHunger + DeltaHunger < Time.time && HungerBar.value > 0)
        {
            lastTimeHunger = Time.time;
            HungerBar.value--;
        }

        if (HungerBar.value == 0 && lastTimeDmg + DeltaHunger < Time.time)
        {
            lastTimeDmg = Time.time;
            DamageHunger();
        }
        
        if (Input.GetKeyDown(KeyCode.R)) Eat();
    }

    
    
    
    
    private void DamageHunger() => PlayerStatsManager.PlayerStats.HP -= PlayerStatsManager.PlayerStats.MaxHP / 100;
    
    
    
    
    
    public void Eat()
    {
        if (PlayerStatsManager.PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Fish <= 0 &&
            HungerBar.value >= HungerBar.maxValue) return;
        HungerBar.value++;
        PlayerStatsManager.UpdateFish(-1);
    }
}