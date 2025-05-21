using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemSellDescription : MonoBehaviour
{
    [SerializeField] private GameObject ItemDescriptionElements;
    
    [SerializeField] private Image ItemSprite;
    [SerializeField] private Image RaritySprite;
    private Item Item;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI Rarity;
    [SerializeField] private TextMeshProUGUI Stats;

    [SerializeField] private CsvData CsvData;
    [SerializeField] private JsonData JsonData;
    [SerializeField] private PlayerStatsManager PlayerStatsManager;

    [SerializeField] private GameObject BackpackCanvas;
    [SerializeField] private GameObject SellButton;
    
    
    
    
    public void SetDescriptionItem(Item item)
    {
        ItemDescriptionElements.SetActive(true);
        SellButton.SetActive(true);
        
        Item = item;
        RaritySprite.sprite = item.RaritySprite;
        ItemSprite.sprite = item.ItemSprite;
        Name.text = item.Name;
        Level.text = "Level " + item.Level;
        Rarity.text = item.Rarity;
        
        SetStatsText();
    }

    public void SetDescriptionMaterial(Material material)
    {
        ItemDescriptionElements.SetActive(true);
        if (material.Name == "Coins") SellButton.SetActive(false);

        Item = null;
        RaritySprite.sprite = material.RaritySprite;
        ItemSprite.sprite = material.MaterialSprite;
        Name.text = material.Name;
        Level.text = material.Number.ToString();
        Rarity.text = "";
        Stats.text = "";
    }


    
    
    
    public void SetStatsText()
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
        else if (Item.Object is CrewMember)
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





    public void SellButtonClicked()
    {
        if (Item is null)
        {
            if (Name.text == "Fish" && PlayerStatsManager.PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Fish >= 1)
            {
                PlayerStatsManager.UpdateFish(-1);
                PlayerCSV playerCsv = CsvData.PlayerCSV[PlayerStatsManager.PlayerStats.Level - 1];
                PlayerStatsManager.UpdateMaterial(playerCsv.Coins / 10,
                    playerCsv.PWD / 10);
            }
            else if (Name.text == "Pure Water Drop" && PlayerStatsManager.PlayerDataManager.PlayerData.Inventory
                         .Backpack.Materials.PureWaterDrop >= 1)
                PlayerStatsManager.UpdateMaterial(5, -1);
        }
        else
        {
            Backpack backpack = PlayerStatsManager.PlayerDataManager.PlayerData.Inventory.Backpack;
            if (Item.Object is Weapon weapon)
            {
                WeaponJSON weaponJson = JsonData.GetWeapon(weapon.Name);
                PlayerStatsManager.UpdateMaterial(weaponJson.Price, 0);
                backpack.Weapons.Remove(weapon);
            }
            else if (Item.Object is Boat boat)
            {
                BoatJSON boatJson = JsonData.GetBoat(boat.Name);
                PlayerStatsManager.UpdateMaterial(boatJson.Price, 0);
                backpack.Boats.Remove(boat);
            }
            else if (Item.Object is Stigma stigma)
            {
                StigmaJSON stigmaJson = JsonData.GetStigma(stigma.Name);
                PlayerStatsManager.UpdateMaterial(stigmaJson.PriceCoin, stigmaJson.PricePWD);
                backpack.Stigmata.Remove(stigma);
            }
            else if (Item.Object is CrewMember crewMember)
            {
                CrewJSON crewJson = JsonData.GetCrew("Navigator", crewMember.Rarity);
                PlayerStatsManager.UpdateMaterial(crewJson.Price, 0);
                if (crewMember is Navigator navigator) backpack.Crew.Navigator.Remove(navigator);
                else if (crewMember is Explorer explorer) backpack.Crew.Explorer.Remove(explorer);
                else if (crewMember is Gunner gunner) backpack.Crew.Gunner.Remove(gunner);
                else if (crewMember is Boatswain boatswain) backpack.Crew.Boatswain.Remove(boatswain);
            }
        }
        transform.parent.GetComponent<SellManager>().InitMaterialInventory();
        ItemDescriptionElements.SetActive(false);
    }
}