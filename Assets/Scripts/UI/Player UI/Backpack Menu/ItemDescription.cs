using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public GameObject ItemDescriptionElements;
    
    public Image Icon;
    public Item Item;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Rarity;
    public TextMeshProUGUI Stats;

    public CsvData CsvData;
    public JsonData JsonData;
    
    
    
    
    
    public void SetDescription(Item item)
    {
        ItemDescriptionElements.SetActive(true);
        
        Item = item;
        Icon.sprite = item.Icon;
        Name.text = item.Name;
        Level.text = "Level " + item.Level;
        Rarity.text = item.Rarity;
        
        SetStatsText();
    }


    
    
    
    private void SetStatsText()
    {
        string text = "";
        List<string> StatList = new List<string>();
        if (Item.Object is Sword)
        {
            WeaponCSV StatDataCSV = CsvData.WeaponCSV[Item.Level - 1];
            StatList = JsonData.GetSword(Item.Name).Stats;
            foreach (string stat in StatList)
            {
                if (stat == "ATK") text += $"ATK: {StatDataCSV.ATK}\n";
                else if (stat == "CritRate") text += $"Crit Rate: {StatDataCSV.CritRate}\n";
                else if (stat == "CritDMG") text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
            }
        }
        else if (Item.Object is Firearm)
        {
            WeaponCSV StatDataCSV = CsvData.WeaponCSV[Item.Level - 1];
            StatList = JsonData.GetFirearm(Item.Name).Stats;
            foreach (string stat in StatList)
            {
                if (stat == "ATK") text += $"ATK: {StatDataCSV.ATK}\n";
                else if (stat == "CritRate") text += $"Crit Rate: {StatDataCSV.CritRate}\n";
                else if (stat == "CritDMG") text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
            }
        }
        else if (Item.Object is Boat)
        {
            BoatCSV StatDataCSV = CsvData.BoatCSV[Item.Level - 1];
            text += $"HP: {StatDataCSV.HP}\n";
            text += $"DEF: {StatDataCSV.DEF}\n";
            text += $"ATk: {StatDataCSV.ATK}\n";
            text += $"Crit Rate: {StatDataCSV.CritRate}\n";
            text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
        }
        else if (Item.Object is Stigma)
        {
            StigmaCSV StatDataCSV = CsvData.StigmaCSV[Item.Level - 1];
            StatList = JsonData.GetStigma(Item.Name).Stats;
            foreach (string stat in StatList)
            {
                if (stat == "HP") text += $"HP: {StatDataCSV.HP}\n";
                else if (stat == "DEF") text += $"DEF: {StatDataCSV.DEF}\n";
                else if (stat == "ATK") text += $"ATK: {StatDataCSV.ATK}\n";
                else if (stat == "CritRate") text += $"Crit Rate: {StatDataCSV.CritRate}\n";
                else if (stat == "CritDMG") text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
            }
        }
        else if (Item.Object is Explorer || Item.Object is Navigator || Item.Object is Gunner ||
                 Item.Object is Boatswain)
        {
            CrewCSV StatDataCSV = CsvData.CrewCSV[Item.Level - 1];
            StatList = JsonData.GetCrew(Item.Name).Stats;
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

        Stats.text = text;
    }
}
