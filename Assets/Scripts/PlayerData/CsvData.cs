using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using CsvHelper;


public class PlayerCSV
{
    public int Level { get; set; }
    public int HP { get; set; }
    public int DEF { get; set; }
    public int ATK { get; set; }
    public int CritRate { get; set; }
    public int CritDMG { get; set; }
    public int Coins { get; set; }
    public int PWD { get; set; }
    public int Storage { get; set; }
}

public class BoatCSV
{
    public int Level { get; set; }
    public int HP { get; set; }
    public int DEF { get; set; }
    public int ATK { get; set; }
    public int CritRate { get; set; }
    public int CritDMG { get; set; }
    public int Speed { get; set; }
    public int Coins { get; set; }
    public int Wood { get; set; }
    public int Steel { get; set; }
    public int Boatswain { get; set; }
    public int Gunner { get; set; }
    public int Navigator { get; set; }
    public int Explorer { get; set; }
}

public class CrewCSV
{
    public int Level { get; set; }
    public int HP { get; set; }
    public int DEF { get; set; }
    public int ATK { get; set; }
    public int CritRate { get; set; }
    public int CritDMG { get; set; }
    public int Speed { get; set; }
    public int Exploration { get; set; }
    public int Coins { get; set; }
    public int PWD { get; set; }
}

public class StigmaCSV
{
    public int Level { get; set; }
    public int HP { get; set; }
    public int DEF { get; set; }
    public int ATK { get; set; }
    public int CritRate { get; set; }
    public int CritDMG { get; set; }
    public int Coins { get; set; }
    public int PWD { get; set; }
}

public class WeaponCSV
{
    public int Level { get; set; }
    public int ATK { get; set; }
    public int CritRate { get; set; }
    public int CritDMG { get; set; }
    public int Coins { get; set; }
    public int PWD { get; set; }
    public int Steel { get; set; }
}

public class EnemyCSV
{
    public int Level { get; set; }
    public int HP { get; set; }
    public int ATK { get; set; }
}

public class EnemyTerestrialCSV : EnemyCSV { }

public class EnemyMarineCSV : EnemyCSV { }










public class CsvData : MonoBehaviour
{
    public List<PlayerCSV> PlayerCSV = new List<PlayerCSV>();
    public List<BoatCSV> BoatCSV = new List<BoatCSV>();
    public List<CrewCSV> CrewCSV = new List<CrewCSV>();
    public List<StigmaCSV> StigmaCSV = new List<StigmaCSV>();
    public List<WeaponCSV> WeaponCSV = new List<WeaponCSV>();
    public List<EnemyTerestrialCSV> EnemyTerestrialCSV = new List<EnemyTerestrialCSV>();
    public List<EnemyMarineCSV> EnemyMarineCSV = new List<EnemyMarineCSV>();
    
    private void LoadPlayerCSV()
    {
        string data = Resources.Load<TextAsset>("Stats/player").text;
        using (StringReader reader = new StringReader(data))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            PlayerCSV = csv.GetRecords<PlayerCSV>().ToList();
        }
    }

    private void LoadBoatCSV()
    {
        string data = Resources.Load<TextAsset>("Stats/items/boatcsv").text;
        using (StringReader reader = new StringReader(data))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            BoatCSV = csv.GetRecords<BoatCSV>().ToList();
        }
    }

    private void LoadCrewCSV()
    {
        string data = Resources.Load<TextAsset>("Stats/items/crewcsv").text;
        using (StringReader reader = new StringReader(data))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            CrewCSV = csv.GetRecords<CrewCSV>().ToList();
        }
    }
    private void LoadStigmaCSV()
    {
        string data = Resources.Load<TextAsset>("Stats/items/stigmacsv").text;
        using (StringReader reader = new StringReader(data))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            StigmaCSV = csv.GetRecords<StigmaCSV>().ToList();
        }
    }

    private void LoadWeaponCSV()
    {
        string data = Resources.Load<TextAsset>("Stats/items/weaponcsv").text;
        using (StringReader reader = new StringReader(data))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            WeaponCSV = csv.GetRecords<WeaponCSV>().ToList();
        }
    }

    private void LoadEnemyTerestrialCSV()
    {
        string data = Resources.Load<TextAsset>("Stats/enemies/terestrial").text;
        using (StringReader reader = new StringReader(data))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            EnemyTerestrialCSV = csv.GetRecords<EnemyTerestrialCSV>().ToList();
        }
    }

    private void LoadEnemyMarineCSV()
    {
        string data = Resources.Load<TextAsset>("Stats/enemies/marine").text;
        using (StringReader reader = new StringReader(data))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            EnemyMarineCSV = csv.GetRecords<EnemyMarineCSV>().ToList();
        }
    }
    
    
    
    
    
    private void Awake()
    {
        LoadPlayerCSV();
        LoadBoatCSV();
        LoadStigmaCSV();
        LoadCrewCSV();
        LoadWeaponCSV();
        LoadEnemyTerestrialCSV();
        LoadEnemyMarineCSV();
    }
}