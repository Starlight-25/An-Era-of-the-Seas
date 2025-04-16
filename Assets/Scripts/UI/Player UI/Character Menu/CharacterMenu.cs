using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    [SerializeField] private GameObject CharacterCanvas;
    private GameObject PreviousCanvas;
    [SerializeField] private GameObject UpgradeCanvas;
    
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    [SerializeField] private PlayerDataManager PlayerDataManager;
    [SerializeField] private JsonData JsonData;
    [SerializeField] private CsvData CsvData;
    
    [SerializeField] private GameObject PlayerElements;
    [SerializeField] private GameObject WeaponElements;
    [SerializeField] private GameObject StigmataElements;
    [SerializeField] private GameObject BoatElements;
    [SerializeField] private GameObject CrewMembersElements;

    [SerializeField] private SwitchHandle SwitchHandle;




    public void SetPreviousCanvas(GameObject previousCanvas) => PreviousCanvas = previousCanvas;
    
    public void ReturnButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        PreviousCanvas.SetActive(true);
        PreviousCanvas = null;
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
        Item weaponItem = new Item(weapon.Name, weapon.Rarity, weapon.Level, weapon);
        Button WeaponButton = WeaponElements.transform.GetChild(0).GetComponent<Button>();
        Image RaritySprite = WeaponButton.transform.GetChild(0).GetComponent<Image>();
        Image WeaponSprite = WeaponButton.transform.GetChild(1).GetComponent<Image>();
        Slider WeaponLevelSlider = WeaponElements.transform.Find("Level (Slider)").GetComponent<Slider>();
        TextMeshProUGUI WeaponLevel = WeaponLevelSlider.transform.Find("Level (Text)").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI WeaponStats = WeaponElements.transform.Find("Stats (Text)").transform.GetChild(0)
            .GetComponent<TextMeshProUGUI>();
        
        WeaponButton.onClick.AddListener(() => SwitchHandle.InitSwitchMenu(weaponItem, WeaponElements));
        RaritySprite.sprite = weaponItem.RaritySprite;
        WeaponSprite.sprite = weaponItem.ItemSprite;
        
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
            Transform StigmaElements = StigmataElements.transform.GetChild(i);
            Button StigmaButton = StigmaElements.transform.GetChild(0).GetComponent<Button>();
            Image RaritySprite = StigmaButton.transform.GetChild(0).GetComponent<Image>();
            Image StigmaSprite = StigmaButton.transform.GetChild(1).GetComponent<Image>();
            Slider StigmaLevelSlider = StigmaElements.transform.Find("Level (Slider)").GetComponent<Slider>();
            TextMeshProUGUI StigmaLevel =
                StigmaLevelSlider.transform.Find("Level (Text)").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI StigmaStats = StigmaElements.transform.Find("Stats (Text)").transform.GetChild(0)
                .GetComponent<TextMeshProUGUI>();
            
            if (PlayerDataManager.PlayerData.Inventory.Equipped.Stigmata[i] is Stigma stigma)
            {
                Item stigmaItem = new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma);
                
                StigmaButton.onClick.AddListener(() => SwitchHandle.InitSwitchMenu(stigmaItem, StigmataElements));
                RaritySprite.sprite = stigmaItem.RaritySprite;
                StigmaSprite.sprite = stigmaItem.ItemSprite;
                Color color = StigmaSprite.color;
                color.a = 1f;
                StigmaSprite.color = color;
                
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
            else
            {
                StigmaButton.onClick.AddListener(() => SwitchHandle.InitSwitchMenu("Stigma", StigmataElements));
                RaritySprite.sprite = Resources.Load<Sprite>("UI/Items/Common");
                Color color = StigmaSprite.color;
                color.a = 0f;
                StigmaSprite.color = color;
                
                StigmaLevelSlider.maxValue = 0;
                StigmaLevelSlider.value = 0;
                StigmaLevel.text = "Level 0/0";
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
        Boat boat = PlayerDataManager.PlayerData.Inventory.Equipped.Boat;
        Item boatItem = new Item(boat.Name, boat.Rarity, boat.Level, boat);
        Button BoatButton = BoatElements.transform.GetChild(0).GetComponent<Button>();
        Image RaritySprite = BoatButton.transform.GetChild(0).GetComponent<Image>();
        Image BoatSprite = BoatButton.transform.GetChild(1).GetComponent<Image>();
        Slider BoatLevelSlider = BoatElements.transform.Find("Level (Slider)").GetComponent<Slider>();
        TextMeshProUGUI BoatLevel = BoatLevelSlider.transform.Find("Level (Text)").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI BoatStats1 = BoatElements.transform.Find("Stats (Text)").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI BoatStats2 = BoatElements.transform.Find("Stats (Text)").transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        BoatButton.onClick.AddListener(() => SwitchHandle.InitSwitchMenu(boatItem, BoatElements));
        RaritySprite.sprite = boatItem.RaritySprite;
        BoatSprite.sprite = boatItem.ItemSprite;
        
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
        InitCrewItems();
    }

    [SerializeField] private GameObject ItemPrefab;
    private void InitCrewItems()
    {
        Transform ExplorerParent = CrewMembersElements.transform.Find("Explorer");
        Transform NavigatorParent = CrewMembersElements.transform.Find("Navigator");
        Transform GunnerParent = CrewMembersElements.transform.Find("Gunner");
        Transform BoatswainParent = CrewMembersElements.transform.Find("Boatswain");
        
        foreach (Transform child in ExplorerParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in NavigatorParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in GunnerParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in BoatswainParent)
        {
            Destroy(child.gameObject);
        }

        int boatLevel = PlayerStatsManager.BoatStats.Level;
        BoatCSV boatCSV = CsvData.BoatCSV[boatLevel - 1];
        for (int i = 0; i < boatCSV.Explorer; i++)
        {
            if (i < PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Explorer.Count)
            {
                Explorer explorer = PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Explorer[i];
                AddItem(new Item("Explorer", explorer.Rarity, explorer.Level, explorer), "Explorer", ExplorerParent);
            }
            else
            {
                AddItem(null, "Explorer", ExplorerParent);
            }
        }
        for (int i = 0; i < boatCSV.Navigator; i++)
        {
            if (i < PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Navigator.Count)
            {
                Navigator navigator = PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Navigator[i];
                AddItem(new Item("Navigator", navigator.Rarity, navigator.Level, navigator), "Explorer", NavigatorParent);
            }
            else
            {
                AddItem(null, "Explorer", NavigatorParent);
            }
        }
        for (int i = 0; i < boatCSV.Gunner; i++)
        {
            if (i < PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Gunner.Count)
            {
                Gunner gunner = PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Gunner[i];
                AddItem(new Item("Gunner", gunner.Rarity, gunner.Level, gunner), "Explorer", GunnerParent);
            }
            else
            {
                AddItem(null, "Explorer", GunnerParent);
            }
        }
        for (int i = 0; i < boatCSV.Boatswain; i++)
        {
            if (i < PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Boatswain.Count)
            {
                Boatswain boatswain = PlayerDataManager.PlayerData.Inventory.Equipped.Crew.Boatswain[i];
                AddItem(new Item("Boatswain", boatswain.Rarity, boatswain.Level, boatswain), "Explorer", BoatswainParent);
            }
            else
            {
                AddItem(null, "Explorer", BoatswainParent);
            }
        }
    }

    private void AddItem(Item item, string itemType, Transform ContentParent)
    {
        GameObject newItem = Instantiate(ItemPrefab, ContentParent);

        ItemButton itemButton = newItem.GetComponent<ItemButton>();
        if(item is not null)
        {
            itemButton.InitItem(item);
        }
        else
        {
            itemButton.Init();
        }
        
        newItem.GetComponent<Button>().onClick.AddListener(() => InitCrewStats(item));
        
        Button switchButton = CrewMembersElements.transform.Find("Switch (Button)").GetComponent<Button>();
        Button unequipButton = CrewMembersElements.transform.Find("Unequip (Button)").GetComponent<Button>();
        if (item is null)
        {
            switchButton.onClick.AddListener(() => SwitchHandle.InitSwitchMenu(itemType, CrewMembersElements));
        }
        else
        {
            switchButton.onClick.AddListener(() => SwitchHandle.InitSwitchMenu(item, CrewMembersElements));
            unequipButton.onClick.AddListener(() => UnequipItem(CrewItem, itemType));
        }
    }

    private Item CrewItem;
    private void InitCrewStats(Item item)
    {
        CrewItem = item;
        TextMeshProUGUI CrewStats = CrewMembersElements.transform.Find("Stats (Text)").GetChild(0).GetComponent<TextMeshProUGUI>();
        if (item is not null)
        {
            
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
        else
        {
            CrewStats.text = "";
        }
    }

    private void UnequipItem(Item item, string itemType)
    {
        if (item is null) return;
        Crew backpackCrew = PlayerDataManager.PlayerData.Inventory.Backpack.Crew;
        Crew equippedCrew = PlayerDataManager.PlayerData.Inventory.Equipped.Crew;

        switch (itemType)
        {
            case "Explorer":
                equippedCrew.Explorer.Remove((Explorer)item.Object);
                backpackCrew.Explorer.Add((Explorer)item.Object);
                backpackCrew.Explorer.Sort((x, y) => x.Level.CompareTo(y.Level));
                break;
            case "Navigator":
                equippedCrew.Navigator.Remove((Navigator)item.Object);
                backpackCrew.Navigator.Add((Navigator)item.Object);
                backpackCrew.Navigator.Sort((x, y) => x.Level.CompareTo(y.Level));
                break;
            case "Gunner":
                equippedCrew.Gunner.Remove((Gunner)item.Object);
                backpackCrew.Gunner.Add((Gunner)item.Object);
                backpackCrew.Gunner.Sort((x, y) => x.Level.CompareTo(y.Level));
                break;
            case "Boatswain":
                equippedCrew.Boatswain.Remove((Boatswain)item.Object);
                backpackCrew.Boatswain.Add((Boatswain)item.Object);
                backpackCrew.Boatswain.Sort((x, y) => x.Level.CompareTo(y.Level));
                break;
        }
        CrewItem = null;
        InitCrewStats(null);
        PlayerDataManager.SavePlayerData();
        PlayerStatsManager.UpdateBoatStats();
        CrewMembersButtonClicked();
    }



    

    public void UpgradeButtonClicked()
    {
        UpgradeUI UpgradeUIScript = UpgradeCanvas.GetComponent<UpgradeUI>();
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
        else if (CrewMembersElements.activeSelf)
        {
            if (CrewItem is not null) UpgradeUIScript.Init(CharacterCanvas, CrewItem);
            else return;
        }
        else return;
        
        CharacterCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
    }

    public void UpgradeStigma1ButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
        Stigma stigma = PlayerDataManager.PlayerData.Inventory.Equipped.Stigmata[0];
        UpgradeCanvas.GetComponent<UpgradeUI>().Init(CharacterCanvas, new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma));
    }
    public void UpgradeStigma2ButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
        Stigma stigma = PlayerDataManager.PlayerData.Inventory.Equipped.Stigmata[1];
        UpgradeCanvas.GetComponent<UpgradeUI>().Init(CharacterCanvas, new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma));
    }
}