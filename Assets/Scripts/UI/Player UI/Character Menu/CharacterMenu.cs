using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUICanvas;
    [SerializeField] private GameObject CharacterCanvas;
    [SerializeField] private GameObject UpgradeCanvas;
    [SerializeField] private UpgradeUI UpgradeUIScript;
    
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    [SerializeField] private PlayerDataManager PlayerDataManager;
    [SerializeField] private JsonData JsonData;
    [SerializeField] private CsvData CsvData;
    
    [SerializeField] private GameObject PlayerElements;
    [SerializeField] private GameObject WeaponElements;
    [SerializeField] private GameObject StigmataElements;
    [SerializeField] private GameObject BoatElements;
    [SerializeField] private GameObject CrewMembersElements;

    
    

    
    public void ReturnButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }

    
    
    
    
    
    public void PlayerButtonClicked()
    {
        WeaponElements.SetActive(false);
        StigmataElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        PlayerElements.SetActive(true);
        InitPlayerStats();
    }

    private void InitPlayerStats()
    {
        Slider PlayerLevelSlider = PlayerElements.transform.Find("Level (Slider)").GetComponent<Slider>();
        TextMeshProUGUI PlayerLevel = PlayerLevelSlider.transform.Find("Level (Text)").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI PlayerStats = PlayerElements.transform.Find("Stats (Text)").transform.GetChild(0)
            .GetComponent<TextMeshProUGUI>();
        
        PlayerLevelSlider.value = PlayerStatsManager.PlayerStats.Level;
        PlayerLevel.text = $"Level {PlayerLevelSlider.value}/100";
        
        string text = "";
        text += $"HP: {PlayerStatsManager.PlayerStats.MaxHP}\n";
        text += $"DEF: {PlayerStatsManager.PlayerStats.MaxDEF}\n";
        text += $"ATK: {PlayerStatsManager.PlayerStats.ATK}\n";
        text += $"Crit Rate: {PlayerStatsManager.PlayerStats.CritRate}\n";
        text += $"Crit DMG: {PlayerStatsManager.PlayerStats.CritDMG}\n";
        PlayerStats.text = text;

    }


    
    

    public void WeaponButtonClicked()
    {
        PlayerElements.SetActive(false);
        StigmataElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        WeaponElements.SetActive(true);
        InitWeaponStats();
    }

    private void InitWeaponStats()
    {
        Weapon weapon = PlayerDataManager.PlayerData.Inventory.Equipped.Weapon;
        Slider WeaponLevelSlider = WeaponElements.transform.Find("Level (Slider)").GetComponent<Slider>();
        TextMeshProUGUI WeaponLevel = WeaponLevelSlider.transform.Find("Level (Text)").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI WeaponStats = WeaponElements.transform.Find("Stats (Text)").transform.GetChild(0)
            .GetComponent<TextMeshProUGUI>();
        
        WeaponLevelSlider.maxValue = JsonData.GetWeapon(weapon.Name).MaxLevel;
        WeaponLevelSlider.value = weapon.Level;
        WeaponLevel.text = $"Level {WeaponLevelSlider.value}/{WeaponLevelSlider.maxValue}";
        
        WeaponCSV StatDataCSV = CsvData.WeaponCSV[weapon.Level - 1];
        List<string> StatList = JsonData.GetWeapon(weapon.Name).Stats;
        string text = "";
        text += $"{weapon.Name}\n";
        foreach (string stat in StatList)
        {
            if (stat == "ATK") text += $"ATK: {StatDataCSV.ATK}\n";
            else if (stat == "CritRate") text += $"Crit Rate: {StatDataCSV.CritRate}\n";
            else if (stat == "CritDMG") text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
        }
        WeaponStats.text = text;
    }
    
    
    
    
    
    public void StigmataButtonClicked()
    {
        PlayerElements.SetActive(false);
        WeaponElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        StigmataElements.SetActive(true);
        InitStigmataStats();
    }

    private void InitStigmataStats()
    {
        for (int i = 0; i < 2; i++)
        {
            if (PlayerDataManager.PlayerData.Inventory.Equipped.Stigmata[i] is Stigma stigma)
            {
                GameObject StigmaElements = StigmataElements.transform.GetChild(i).GetComponent<GameObject>();
                Slider StigmaLevelSlider = StigmaElements.transform.Find("Level (Slider)").GetComponent<Slider>();
                TextMeshProUGUI StigmaLevel =
                    StigmaLevelSlider.transform.Find("Level (Text)").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI StigmaStats = StigmaElements.transform.Find("Stats (Text)").transform.GetChild(0)
                    .GetComponent<TextMeshProUGUI>();

                StigmaLevelSlider.maxValue = JsonData.GetStigma(stigma.Name).MaxLevel;
                StigmaLevelSlider.value = stigma.Level;
                StigmaLevel.text = $"Level {StigmaLevelSlider.value}/{StigmaLevelSlider.maxValue}\n";

                StigmaCSV StatDataCSV = CsvData.StigmaCSV[stigma.Level - 1];
                List<string> StatList = JsonData.GetStigma(stigma.Name).Stats;
                string text = "";
                text += $"{stigma.Name}\n";
                foreach (string stat in StatList)
                {
                    if (stat == "HP") text += $"HP: {StatDataCSV.HP}\n";
                    else if (stat == "DEF") text += $"DEF: {StatDataCSV.DEF}\n";
                    else if (stat == "ATK") text += $"ATK: {StatDataCSV.ATK}\n";
                    else if (stat == "CritRate") text += $"Crit Rate: {StatDataCSV.CritRate}\n";
                    else if (stat == "CritDMG") text += $"Crit DMG: {StatDataCSV.CritDMG}\n";
                }
                StigmaStats.text = text;
            }
        }
    }
    
    
    
    
    
    public void BoatButtonClicked()
    {
        PlayerElements.SetActive(false);
        WeaponElements.SetActive(false);
        StigmataElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        BoatElements.SetActive(true);
        InitBoatStats();
    }

    private void InitBoatStats()
    {
        Slider BoatLevelSlider = BoatElements.transform.Find("Level (Slider)").GetComponent<Slider>();
        TextMeshProUGUI BoatLevel = BoatLevelSlider.transform.Find("Level (Text)").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI BoatStats1 = BoatElements.transform.Find("Stats (Text)").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI BoatStats2 = BoatElements.transform.Find("Stats (Text)").transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        BoatLevelSlider.maxValue = JsonData.GetBoat(PlayerStatsManager.BoatStats.Name).MaxLevel;
        BoatLevelSlider.value = PlayerStatsManager.BoatStats.Level;
        BoatLevel.text = $"Level {BoatLevelSlider.value}/{BoatLevelSlider.maxValue}";

        string text1 = "";
        text1 += $"{PlayerStatsManager.BoatStats.Name}\n";
        text1 += $"HP: {PlayerStatsManager.BoatStats.MaxHP}\n";
        text1 += $"DEF: {PlayerStatsManager.BoatStats.MaxDEF}\n";
        text1 += $"Speed: {PlayerStatsManager.BoatStats.Speed}\n";
        BoatStats1.text = text1;
        
        string text2 = "\n";
        text2 += $"ATK: {PlayerStatsManager.BoatStats.ATK}\n";
        text2 += $"Crit Rate: {PlayerStatsManager.BoatStats.CritRate}\n";
        text2 += $"Crit DMG: {PlayerStatsManager.BoatStats.CritDMG}\n";
        BoatStats2.text = text2;
    }
    
    
    
    
    
    public void CrewMembersButtonClicked()
    {
        PlayerElements.SetActive(false);
        WeaponElements.SetActive(false);
        StigmataElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(true);
    }

    [SerializeField] private GameObject ItemPrefab;
    private void InitCrewItems()
    {
        Transform ExplorerParent = CrewMembersElements.transform.Find("Explorer");
        Transform NavigatorParent = CrewMembersElements.transform.Find("Navigator");
        Transform GunnerParent = CrewMembersElements.transform.Find("Gunner");
        Transform BoatswainParent = CrewMembersElements.transform.Find("Boatswain");

        int boatLevel = PlayerStatsManager.BoatStats.Level;
        BoatCSV boatCSV = CsvData.BoatCSV[boatLevel - 1];

        for (int i = 0; i < boatCSV.Explorer; i++)
        {
            if (PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Explorer[i] is Explorer explorer)
            {
                AddItem(new Item("Explorer", explorer.Rarity, explorer.Level, explorer), ExplorerParent);
            }
            else
            {
                AddItem(null, ExplorerParent);
            }
        }
        for (int i = 0; i < boatCSV.Navigator; i++)
        {
            if (PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Navigator[i] is Navigator navigator)
            {
                AddItem(new Item("Navigator", navigator.Rarity, navigator.Level, navigator), NavigatorParent);
            }
            else
            {
                AddItem(null, NavigatorParent);
            }
        }
        for (int i = 0; i < boatCSV.Gunner; i++)
        {
            if (PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Gunner[i] is Gunner gunner)
            {
                AddItem(new Item("Gunner", gunner.Rarity, gunner.Level, gunner), GunnerParent);
            }
            else
            {
                AddItem(null, GunnerParent);
            }
        }
        for (int i = 0; i < boatCSV.Boatswain; i++)
        {
            if (PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Boatswain[i] is Boatswain boatswain)
            {
                AddItem(new Item("Boatswain", boatswain.Rarity, boatswain.Level, boatswain), BoatswainParent);
            }
            else
            {
                AddItem(null, BoatswainParent);
            }
        }
    }

    private void AddItem(Item item, Transform ContentParent)
    {
        GameObject newItem = Instantiate(ItemPrefab, ContentParent);

        ItemButton itemButton = newItem.GetComponent<ItemButton>();
        itemButton.InitItem(item);
        
        newItem.GetComponent<Button>().onClick.AddListener(() => InitCrewStats(item));
    }

    private Item CrewItem;
    private void InitCrewStats(Item item)
    {
        CrewItem = item;
        if (item is not null)
        {
            TextMeshProUGUI CrewStats = CrewMembersElements.transform.Find("Stats (Text)").GetComponent<TextMeshProUGUI>();
            
            CrewCSV StatDataCSV = CsvData.CrewCSV[item.Level - 1];
            List<string> StatList = JsonData.GetCrew(item.Name, item.Rarity).Stats;
            
            string text = $"{item.Name} | Lvl {item.Level}/{JsonData.GetCrew(item.Name, item.Rarity).MaxLevel}\n";
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
            CrewStats.text = text;
        }
    }



    

    public void UpgradeButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
        if (PlayerElements.activeSelf)
        {
            UpgradeUIScript.Init(CharacterCanvas);
        }
        else if (WeaponElements.activeSelf)
        {
            Weapon weapon = PlayerDataManager.PlayerData.Inventory.Equipped.Weapon;
            UpgradeUIScript.Init(CharacterCanvas, new Item(weapon.Name, weapon.Rarity, weapon.Level, weapon));
        }
        else if (BoatElements.activeSelf)
        {
            Boat boat = PlayerDataManager.PlayerData.Inventory.Equipped.Boat;
            UpgradeUIScript.Init(CharacterCanvas, new Item(boat.Name, boat.Rarity, boat.Level, boat));
        }
        else if (CrewMembersElements.activeSelf && CrewItem is not null)
        {
            UpgradeUIScript.Init(CharacterCanvas, CrewItem);
        }
    }

    public void UpgradeStigma1ButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
        Stigma stigma = PlayerDataManager.PlayerData.Inventory.Equipped.Stigmata[0];
        UpgradeUIScript.Init(CharacterCanvas, new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma));
    }
    public void UpgradeStigma2ButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
        Stigma stigma = PlayerDataManager.PlayerData.Inventory.Equipped.Stigmata[1];
        UpgradeUIScript.Init(CharacterCanvas, new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma));
    }
}