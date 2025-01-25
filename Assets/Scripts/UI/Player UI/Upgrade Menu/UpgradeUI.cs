using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeCanvas;
    private GameObject PreviousCanvas;
    
    [SerializeField] private PlayerDataManager PlayerDataManager;
    [SerializeField] private CsvData CsvData;
    [SerializeField] private JsonData JsonData;
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    private Item Item;

    [SerializeField] private Transform ItemImage;
    
    [SerializeField] private Button upgrade1XButton;
    [SerializeField] private Button upgrade2XButton;
    [SerializeField] private Button upgrade5XButton;
    [SerializeField] private Button upgrade10XButton;

    [SerializeField] private OwnedMaterial OwnedMaterial;
    [SerializeField] private ItemStats ItemStats;

    private Dictionary<int, List<Tuple<string, int>>> UpgradeMaterials = new ();


    private void Start()
    {
        upgrade1XButton.onClick.AddListener(Upgrade1xClicked);
        upgrade2XButton.onClick.AddListener(Upgrade2xClicked);
        upgrade5XButton.onClick.AddListener(Upgrade5xClicked);
        upgrade10XButton.onClick.AddListener(Upgrade10xClicked);
        if (Item is not null)
        {
            ItemStats.SetItemStats(Item);
        }
        else
        {
            ItemStats.SetPlayerStats();
        }
        SetNecessaryMaterial();
        SetMaterialText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void ReturnButtonClicked()
    {
        UpgradeCanvas.SetActive(false);
        PreviousCanvas.SetActive(true);
        PreviousCanvasUpdate();
    }

    private void PreviousCanvasUpdate()
    {
        if (PreviousCanvas.name == "Character Menu (Canvas)")
        {
            CharacterMenu characterMenu = PreviousCanvas.GetComponent<CharacterMenu>();
            GameObject PlayerElements = PreviousCanvas.transform.GetChild(1).gameObject;
            GameObject WeaponElements = PreviousCanvas.transform.GetChild(3).gameObject;
            GameObject StigmaElements = PreviousCanvas.transform.GetChild(5).gameObject;
            GameObject BoatElements = PreviousCanvas.transform.GetChild(7).gameObject;
            GameObject CrewElements = PreviousCanvas.transform.GetChild(9).gameObject;

            if (PlayerElements.activeSelf) characterMenu.PlayerButtonClicked();
            else if (WeaponElements.activeSelf) characterMenu.WeaponButtonClicked();
            else if (StigmaElements.activeSelf) characterMenu.StigmataButtonClicked();
            else if (BoatElements.activeSelf) characterMenu.BoatButtonClicked();
            else if (CrewElements.activeSelf) characterMenu.CrewMembersButtonClicked();
        }
        else if (PreviousCanvas.name == "Backpack Menu (Canvas)")
        {
            ItemDescription itemDescription = PreviousCanvas.transform.GetChild(7).GetComponent<ItemDescription>();
            itemDescription.SetStatsText();
        }
    }





    public void Init(GameObject previousCanvas)
    {
        PreviousCanvas = previousCanvas;
        Item = null;
        Image RaritySprite = ItemImage.transform.GetChild(0).GetComponent<Image>();
        Image PlayerSprite = ItemImage.transform.GetChild(1).GetComponent<Image>();
        RaritySprite.sprite = Resources.Load<Sprite>("UI/Items/Legendary");
        PlayerSprite.sprite = Resources.Load<Sprite>("UI/Items/Player");
        ItemStats.SetPlayerStats();
        SetNecessaryMaterial();
        SetMaterialText();
    }
    
    public void Init(GameObject previousCanvas, Item item)
    {
        PreviousCanvas = previousCanvas;
        Item = item;
        Image RaritySprite = ItemImage.transform.GetChild(0).GetComponent<Image>();
        Image ItemSprite = ItemImage.transform.GetChild(1).GetComponent<Image>();
        RaritySprite.sprite = Item.RaritySprite;
        ItemSprite.sprite = Item.ItemSprite;
        ItemStats.SetItemStats(Item);
        SetNecessaryMaterial();
        SetMaterialText();

    }
    




    private void SetNecessaryMaterial()
    {
        SetMaterial(1);
        SetMaterial(2);
        SetMaterial(5);
        SetMaterial(10);
    }
    
    private void SetMaterial(int nbLevel)
    {
        UpgradeMaterials[nbLevel] = new List<Tuple<string, int>>();
        if (Item is null && PlayerDataManager.PlayerData.Level + nbLevel <= 100)
        {
            (int coins, int pwd) = (0, 0);
            for (int i = 0; i < nbLevel; i++)
            {
                PlayerCSV playerCsv = CsvData.PlayerCSV[PlayerDataManager.PlayerData.Level + i];
                (coins, pwd) = (coins + playerCsv.Coins, pwd + playerCsv.PWD);
            }
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("Coins", coins));
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("PWD", pwd));
        }
        else if (Item.Object is Weapon && Item.Level + nbLevel <= JsonData.GetWeapon(Item.Name).MaxLevel)
        {
            (int coins, int pwd, int steal) = (0, 0, 0);
            for (int i = 0; i < nbLevel; i++)
            {
                WeaponCSV weaponCsv = CsvData.WeaponCSV[Item.Level + i];
                (coins, pwd, steal) = (coins + weaponCsv.Coins, pwd + weaponCsv.PWD, steal + weaponCsv.Steel);
            }
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("Coins", coins));
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("PWD", pwd));
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("Steal", steal));
        }
        else if (Item.Object is Stigma && Item.Level + nbLevel <= JsonData.GetStigma(Item.Name).MaxLevel)
        {
            (int coins, int pwd) = (0, 0);
            for (int i = 0; i < nbLevel; i++)
            {
                StigmaCSV stigmaCsv = CsvData.StigmaCSV[Item.Level + i];
                (coins, pwd) = (coins + stigmaCsv.Coins, pwd + stigmaCsv.PWD);
            }
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("Coins", coins));
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("PWD", pwd));
        }
        else if (Item.Object is Boat && Item.Level + nbLevel <= JsonData.GetBoat(Item.Name).MaxLevel)
        {
            (int coins, int wood, int steal) = (0, 0, 0);
            for (int i = 0; i < nbLevel; i++)
            {
                BoatCSV boatCsv = CsvData.BoatCSV[Item.Level + i];
                (coins, wood, steal) = (coins + boatCsv.Coins, wood + boatCsv.Wood, steal + boatCsv.Steel);
            }
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("Coins", coins));
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("Wood", wood));
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("Steal", steal));
        }
        else if (Item.Object is CrewMember && Item.Level + nbLevel <= JsonData.GetCrew(Item.Name, Item.Rarity).MaxLevel)
        {
            (int coins, int pwd) = (0, 0);
            for (int i = 0; i < nbLevel; i++)
            {
                CrewCSV crewCsv = CsvData.CrewCSV[Item.Level + i];
                (coins, pwd) = (coins + crewCsv.Coins, pwd + crewCsv.PWD);
            }
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("Coins", coins));
            UpgradeMaterials[nbLevel].Add(new Tuple<string, int>("PWD", pwd));
        }
    }


    
    
    
    private void SetMaterialText()
    {
        List<TextMeshProUGUI> MaterialText = new List<TextMeshProUGUI>();
        MaterialText.Add(upgrade1XButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());
        MaterialText.Add(upgrade2XButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());
        MaterialText.Add(upgrade5XButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());
        MaterialText.Add(upgrade10XButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());

        int i = 0;
        foreach (int nbLevel in UpgradeMaterials.Keys)
        {
            string text = "";
            foreach ((string material, int num) in UpgradeMaterials[nbLevel])
            {
                text += $"{material}: {num}\n";
            }
            MaterialText[i].text = text;
            i++;
        }
    }
    
    
    
    
    
    
    
    
    
    
    private void Upgrade1xClicked()
    {
        if (RemoveMaterial(1))
        {
            UpgradeItem(1);
        }
    }
    
    
    
    
    
    private void Upgrade2xClicked()
    {
        if (RemoveMaterial(2))
        {
            UpgradeItem(2);
        }

    }
    
    
    
    
    
    private void Upgrade5xClicked()
    {
        if (RemoveMaterial(5))
        {
            UpgradeItem(5);
        }

    }
    
    
    
    
    
    private void Upgrade10xClicked()
    {
        if (RemoveMaterial(10))
        {
            UpgradeItem(10);
        }

    }

    
    
    
    

    private bool RemoveMaterial(int nbLevel)
    {
        List<TextMeshProUGUI> MaterialText = new List<TextMeshProUGUI>();
        MaterialText.Add(upgrade1XButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());
        MaterialText.Add(upgrade2XButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());
        MaterialText.Add(upgrade5XButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());
        MaterialText.Add(upgrade10XButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>());
        switch (nbLevel)
        {
            case 1 when MaterialText[0].text == "":
                return false;
            case 2 when MaterialText[1].text == "":
                return false;
            case 5 when MaterialText[2].text == "":
                return false;
            case 10 when MaterialText[3].text == "":
                return false;
        }
        
        Materials materials = PlayerDataManager.PlayerData.Inventory.Backpack.Materials;
        Dictionary<string, int> PlayerMaterials = new Dictionary<string, int>()
        {
            { "Coins", PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Coins },
            { "PWD", PlayerDataManager.PlayerData.Inventory.Backpack.Materials.PureWaterDrop },
            { "Wood", PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Wood },
            { "Steal", PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Steel }
        };
        foreach ((string material, int num) in UpgradeMaterials[nbLevel])
        {
            if (PlayerMaterials[material] < num) return false;
        }

        foreach ((string material, int num) in UpgradeMaterials[nbLevel])
        {
            PlayerMaterials[material] -= num;
            if (material == "Coins") PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Coins -= num;
            else if (material == "PWD") PlayerDataManager.PlayerData.Inventory.Backpack.Materials.PureWaterDrop -= num;
            else if (material == "Wood") PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Wood -= num;
            else if (material == "Steal") PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Steel -= num;
        }
        OwnedMaterial.UpdateNumber();
        return true;
    }





    private void UpgradeItem(int nbLevel)
    {
        if (Item is null)
        {
            PlayerDataManager.PlayerData.Level += nbLevel;
        }
        else if (Item.Object is Weapon weapon)
        {
            weapon.Level += nbLevel;
            Item.Level = weapon.Level;
        }
        else if (Item.Object is Stigma stigma)
        {
            stigma.Level += nbLevel;
            Item.Level = stigma.Level;
        }
        else if (Item.Object is Boat boat)
        {
            boat.Level += nbLevel;
            Item.Level = boat.Level;
        }
        else if (Item.Object is CrewMember crewMember)
        {
            crewMember.Level += nbLevel;
            Item.Level = crewMember.Level;
        }
        
        PlayerDataManager.SavePlayerData();
        PlayerStatsManager.UpdatePlayerStats();
        PlayerStatsManager.UpdateBoatStats();
        if (Item is not null)
        {
            ItemStats.SetItemStats(Item);
        }
        else
        {
            ItemStats.SetPlayerStats();
        }
        SetNecessaryMaterial();
        SetMaterialText();
    }
}
