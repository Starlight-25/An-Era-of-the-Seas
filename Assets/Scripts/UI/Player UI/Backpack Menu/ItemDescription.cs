using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private GameObject ItemDescriptionElements;
    
    [SerializeField] private Image Icon;
    private Item Item;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI Rarity;
    [SerializeField] private TextMeshProUGUI Stats;

    [SerializeField] private CsvData CsvData;
    [SerializeField] private JsonData JsonData;

    [SerializeField] private GameObject BackpackCanvas;
    [SerializeField] private GameObject UpgradeCanvas;
    [SerializeField] private UpgradeUI UpgradeUIScript;
    
    
    
    
    public void SetDescriptionItem(Item item)
    {
        ItemDescriptionElements.SetActive(true);
        
        Item = item;
        Icon.sprite = item.Icon;
        Name.text = item.Name;
        Level.text = "Level " + item.Level;
        Rarity.text = item.Rarity;
        
        SetStatsText();
    }

    public void SetDescriptionMaterial(Material material)
    {
        ItemDescriptionElements.SetActive(true);

        Item = null;
        Icon.sprite = material.Icon;
        Name.text = material.Name;
        Level.text = material.Number.ToString();
        Rarity.text = "";
        Stats.text = "";
    }


    
    
    
    private void SetStatsText()
    {
        string text = "";
        List<string> StatList = new List<string>();
        if (Item.Object is Weapon)
        {
            WeaponCSV StatDataCSV = CsvData.WeaponCSV[Item.Level - 1];
            StatList = JsonData.GetWeapon(Item.Name).Stats;
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
            StatList = JsonData.GetCrew(Item.Name, Item.Rarity).Stats;
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





    public void UpgradeButtonClicked()
    {
        BackpackCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
        UpgradeUIScript.Init(BackpackCanvas, Item);
    }
}
