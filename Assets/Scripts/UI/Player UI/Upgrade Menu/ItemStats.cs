using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    [SerializeField] private CsvData CsvData;
    [SerializeField] private JsonData JsonData;
    [SerializeField] private PlayerDataManager PlayerDataManager;
    [SerializeField] private TextMeshProUGUI StatsText;




    public void SetPlayerStats()
    {
        int Level = PlayerDataManager.PlayerData.Level;
        PlayerCSV playerCsv = CsvData.PlayerCSV[Level - 1];
        string text = $"{PlayerDataManager.PlayerData.Pseudo}\n";
        text += $"Level: {playerCsv.Level}/100\n";
        text += $"HP: {playerCsv.HP}\n";
        text += $"DEF: {playerCsv.DEF}\n";
        text += $"ATK: {playerCsv.ATK}\n";
        text += $"Crit Rate: {playerCsv.CritRate}\n";
        text += $"Crit DMG: {playerCsv.CritDMG}\n";
        StatsText.text = text;
    }
    
    
    
    
    
    public void SetItemStats(Item item)
    {
        string text = "";
        text += $"{item.Name}\n";
        text += $"Rarity: {item.Rarity}\n";
        List<string> StatList = new List<string>();
        if (item.Object is Weapon)
        {
            WeaponCSV StatDataCSV = CsvData.WeaponCSV[item.Level - 1];
            StatList = JsonData.GetWeapon(item.Name).Stats;
            text += $"Level: {item.Level}/{JsonData.GetWeapon(item.Name).MaxLevel}\n";
            foreach (string stat in StatList)
            {
                if (stat == "ATK") text += $"ATK: {StatDataCSV.ATK}\n";
                else if (stat == "CritRate") text += $"Crit Rate: {StatDataCSV.CritRate}\n";
                else if (stat == "CritDMG") text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
            }
        }
        else if (item.Object is Boat)
        {
            BoatCSV StatDataCSV = CsvData.BoatCSV[item.Level - 1];
            text += $"Level: {item.Level}/{JsonData.GetBoat(item.Name).MaxLevel}\n";
            text += $"HP: {StatDataCSV.HP}\n";
            text += $"DEF: {StatDataCSV.DEF}\n";
            text += $"ATk: {StatDataCSV.ATK}\n";
            text += $"Crit Rate: {StatDataCSV.CritRate}\n";
            text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
        }
        else if (item.Object is Stigma)
        {
            StigmaCSV StatDataCSV = CsvData.StigmaCSV[item.Level - 1];
            StatList = JsonData.GetStigma(item.Name).Stats;
            text += $"Level: {item.Level}/{JsonData.GetStigma(item.Name).MaxLevel}\n";
            foreach (string stat in StatList)
            {
                if (stat == "HP") text += $"HP: {StatDataCSV.HP}\n";
                else if (stat == "DEF") text += $"DEF: {StatDataCSV.DEF}\n";
                else if (stat == "ATK") text += $"ATK: {StatDataCSV.ATK}\n";
                else if (stat == "CritRate") text += $"Crit Rate: {StatDataCSV.CritRate}\n";
                else if (stat == "CritDMG") text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
            }
        }
        else if (item.Object is CrewMember)
        {
            CrewCSV StatDataCSV = CsvData.CrewCSV[item.Level - 1];
            StatList = JsonData.GetCrew(item.Name, item.Rarity).Stats;
            text += $"Level: {item.Level}/{JsonData.GetCrew(item.Name, item.Rarity).MaxLevel}\n";
            foreach (string stat in StatList)
            {
                if (stat == "HP") text += $"HP: {StatDataCSV.HP}\n";
                else if (stat == "DEF") text += $"DEF: {StatDataCSV.DEF}\n";
                else if (stat == "ATK") text += $"ATK: {StatDataCSV.ATK}\n";
                else if (stat == "CritRate") text += $"Crit Rate: {StatDataCSV.CritRate}\n";
                else if (stat == "CritDMG") text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
                else if (stat == "Speed") text += $"Speed: {StatDataCSV.Speed}\n";
                else if (stat == "Exploration") text += $"Exploration: {StatDataCSV.Exploration}\n";
            }
        }
        StatsText.text = text;
    }
}
