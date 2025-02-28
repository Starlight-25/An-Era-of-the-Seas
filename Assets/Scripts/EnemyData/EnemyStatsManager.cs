using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats
{
    public int Level;
    public int MaxHP;
    public int HP;
    public int ATK;
}

public class EnemyTerestrialStats : EnemyStats { }

public class EnemyMarineStats : EnemyStats { }
public class EnemyStatsManager : MonoBehaviour
{
    private PlayerStatsManager PlayerStatsManager;
    private CsvData CsvData;

    public EnemyTerestrialStats EnemyTerestrialStats = new EnemyTerestrialStats();
    public EnemyMarineStats EnemyMarineStats = new EnemyMarineStats();
    
    
    
    
    
    private void Start()
    {
        PlayerStatsManager = FindFirstObjectByType<PlayerStatsManager>().GetComponent<PlayerStatsManager>();
        CsvData = PlayerStatsManager.CsvData;
        UpdateEnemyTerestrialStats();
        UpdateEnemyMarineStats();
    }





    private void InitEnemyTerestrialStats()
    {
        EnemyTerestrialStats.Level = PlayerStatsManager.PlayerStats.Level;
        EnemyTerestrialStats.MaxHP = CsvData.EnemyTerestrialCSV[EnemyTerestrialStats.Level - 1].HP;
        EnemyTerestrialStats.HP = EnemyTerestrialStats.MaxHP;
        EnemyTerestrialStats.ATK = CsvData.EnemyTerestrialCSV[EnemyTerestrialStats.Level - 1].ATK;
    }

    public void UpdateEnemyTerestrialStats() => InitEnemyTerestrialStats();



    

    private void InitEnemyMarineStats()
    {
        EnemyMarineStats.Level = PlayerStatsManager.PlayerStats.Level;
        EnemyMarineStats.MaxHP = CsvData.EnemyMarineCSV[EnemyMarineStats.Level - 1].HP;
        EnemyMarineStats.HP = EnemyTerestrialStats.MaxHP;
        EnemyMarineStats.ATK = CsvData.EnemyMarineCSV[EnemyMarineStats.Level - 1].ATK;
    }

    public void UpdateEnemyMarineStats() => InitEnemyMarineStats();
}