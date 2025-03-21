using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlayerStats
{
    public int Level { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public int MaxDEF { get; set; }
    public int DEF { get; set; }
    public int ATK { get; set; }
    public int CritRate { get; set; }
    public int CritDMG { get; set; }
    public int Storage { get; set; }
}

public class BoatStats
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public int MaxDEF { get; set; }
    public int DEF { get; set; }
    public int ATK { get; set; }
    public int CritRate { get; set; }
    public int CritDMG { get; set; }
    public int Speed { get; set; }
}










public class PlayerStatsManager : MonoBehaviour
{
    public PlayerDataManager PlayerDataManager;
    public CsvData CsvData;
    public JsonData JsonData;

    public PlayerStats PlayerStats = new PlayerStats();
    public BoatStats BoatStats = new BoatStats();

    
    
    
    
    private void Awake()
    {
        UpdatePlayerStats();
        UpdateBoatStats();
    }
    
    
    
    
    
    private void InitPlayerStats()
    {
        PlayerStats.Level = PlayerDataManager.PlayerData.Level;
        PlayerStats.MaxHP = CsvData.PlayerCSV[PlayerStats.Level - 1].HP;
        PlayerStats.MaxDEF = CsvData.PlayerCSV[PlayerStats.Level - 1].DEF;
        PlayerStats.ATK = CsvData.PlayerCSV[PlayerStats.Level - 1].ATK;
        PlayerStats.CritRate = CsvData.PlayerCSV[PlayerStats.Level - 1].CritRate;
        PlayerStats.CritDMG = CsvData.PlayerCSV[PlayerStats.Level - 1].CritDMG;
        PlayerStats.Storage = CsvData.PlayerCSV[PlayerStats.Level - 1].Storage;
    }

    
    
    
    
    private void SetPlayerBonus()
    {
        var weaponCsv = CsvData.WeaponCSV;
        Weapon weapon = PlayerDataManager.PlayerData.Inventory.Equipped.Weapon;
        List<string> stats = JsonData.GetWeapon(weapon.Name).Stats;
        foreach (var stat in stats)
        {
            if (stat == "ATK") PlayerStats.ATK += weaponCsv[weapon.Level - 1].ATK;
            else if (stat == "CritRate") PlayerStats.CritRate += weaponCsv[weapon.Level - 1].CritRate;
            else if (stat == "CritDMG") PlayerStats.CritDMG += weaponCsv[weapon.Level - 1].CritDMG;
        }

        var stigmaCsv = CsvData.StigmaCSV;
        if (PlayerDataManager.PlayerData.Inventory.Equipped.Stigmata[0] is Stigma stigma1)
        {
            stats = JsonData.StigmaJSON.SingleOrDefault(e => e.Name == stigma1.Name).Stats;
            foreach (var stat in stats)
            {
                if (stat == "HP") PlayerStats.MaxHP += stigmaCsv[stigma1.Level - 1].HP;
                else if (stat == "DEF") PlayerStats.MaxDEF += stigmaCsv[stigma1.Level - 1].DEF;
                else if (stat == "ATK") PlayerStats.ATK += stigmaCsv[stigma1.Level - 1].ATK;
                else if (stat == "CritRate") PlayerStats.CritRate += stigmaCsv[stigma1.Level - 1].CritRate;
                else if (stat == "CritDMG") PlayerStats.CritDMG += stigmaCsv[stigma1.Level - 1].CritDMG;
            }
        }

        if (PlayerDataManager.PlayerData.Inventory.Equipped.Stigmata[1] is Stigma stigma2)
        {
            stats = JsonData.StigmaJSON.SingleOrDefault(e => e.Name == stigma2.Name).Stats;
            foreach (var stat in stats)
            {
                if (stat == "HP") PlayerStats.MaxHP += stigmaCsv[stigma2.Level - 1].HP;
                else if (stat == "DEF") PlayerStats.MaxDEF += stigmaCsv[stigma2.Level - 1].DEF;
                else if (stat == "ATK") PlayerStats.ATK += stigmaCsv[stigma2.Level - 1].ATK;
                else if (stat == "CritRate") PlayerStats.CritRate += stigmaCsv[stigma2.Level - 1].CritRate;
                else if (stat == "CritDMG") PlayerStats.CritDMG += stigmaCsv[stigma2.Level - 1].CritDMG;
            }
        }
    }

    public void UpdatePlayerStats()
    {
        InitPlayerStats();
        SetPlayerBonus();
        PlayerStats.HP = PlayerStats.MaxHP;
        PlayerStats.DEF = PlayerStats.MaxDEF;
    }





    private void InitBoatStats()
    {
        BoatStats.Name = PlayerDataManager.PlayerData.Inventory.Equipped.Boat.Name;
        BoatStats.Level = PlayerDataManager.PlayerData.Inventory.Equipped.Boat.Level;
        BoatStats.MaxHP = CsvData.BoatCSV[BoatStats.Level - 1].HP;
        BoatStats.MaxDEF = CsvData.BoatCSV[BoatStats.Level - 1].DEF;
        BoatStats.ATK = CsvData.BoatCSV[BoatStats.Level - 1].ATK;
        BoatStats.CritRate = CsvData.BoatCSV[BoatStats.Level - 1].CritRate;
        BoatStats.CritDMG = CsvData.BoatCSV[BoatStats.Level - 1].CritDMG;
        BoatStats.Speed = CsvData.BoatCSV[BoatStats.Level - 1].Speed;
    }

    private void SetBoatBonus()
    {
        foreach (var boatswain in PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Boatswain)
        {
            BoatStats.MaxHP += CsvData.CrewCSV[boatswain.Level - 1].HP;
            BoatStats.MaxDEF += CsvData.CrewCSV[boatswain.Level - 1].DEF;
        }

        foreach (var gunner in PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Gunner)
        {
            BoatStats.ATK += CsvData.CrewCSV[gunner.Level - 1].ATK;
            BoatStats.CritRate += CsvData.CrewCSV[gunner.Level - 1].CritRate;
            BoatStats.CritDMG += CsvData.CrewCSV[gunner.Level - 1].CritDMG;
        }

        foreach (var navigator in PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Navigator)
        {
            BoatStats.Speed += CsvData.CrewCSV[navigator.Level - 1].Speed;
        }
    }

    public void UpdateBoatStats()
    {
        InitBoatStats();
        SetBoatBonus();
        BoatStats.HP = BoatStats.MaxHP;
        BoatStats.DEF = BoatStats.MaxDEF;
    }







    private int GetTotalItem()
    {
        Inventory Inventory = PlayerDataManager.PlayerData.Inventory;
        int totalItem = 0;
        totalItem += Inventory.Backpack.Weapons.Count + 1;
        totalItem += Inventory.Backpack.Boats.Count + 1;
        totalItem += Inventory.Backpack.Stigmata.Count + Inventory.Equipped.Stigmata.Count;
        totalItem += Inventory.Backpack.Crew.Navigator.Count + Inventory.Equipped.Crew.Navigator.Count;
        totalItem += Inventory.Backpack.Crew.Gunner.Count + Inventory.Equipped.Crew.Gunner.Count;
        totalItem += Inventory.Backpack.Crew.Explorer.Count + Inventory.Equipped.Crew.Explorer.Count;
        totalItem += Inventory.Backpack.Crew.Boatswain.Count + Inventory.Equipped.Crew.Boatswain.Count;
        return totalItem;
    }
    
    public bool AddItem(object item)
    {
        if (GetTotalItem() >= PlayerStats.Storage) return false;

        Backpack Backpack = PlayerDataManager.PlayerData.Inventory.Backpack;
        if (item is Weapon weapon) Backpack.Weapons.Add(weapon);
        else if (item is Boat boat) Backpack.Boats.Add(boat);
        else if (item is Stigma stigma) Backpack.Stigmata.Add(stigma);
        else if (item is Explorer explorer) Backpack.Crew.Explorer.Add(explorer);
        else if (item is Navigator navigator) Backpack.Crew.Navigator.Add(navigator);
        else if (item is Gunner gunner) Backpack.Crew.Gunner.Add(gunner);
        else if (item is Boatswain boatswain) Backpack.Crew.Boatswain.Add(boatswain);
        return true;
    }

    public void AddMaterial(int coins, int PDW, int wood, int steel)
    {
        Materials Material = PlayerDataManager.PlayerData.Inventory.Backpack.Materials;
        Material.Coins += coins;
        Material.PureWaterDrop += PDW;
        Material.Wood += wood;
        Material.Steel += steel;
    }
}