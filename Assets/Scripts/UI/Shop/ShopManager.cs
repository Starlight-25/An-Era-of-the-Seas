using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private Transform ContentParent;
    [SerializeField] private ItemShopDescription ItemShopDescription;
    private OwnedMaterial OwnedMaterial;
    private List<Item> ItemShopList;

    private void OnEnable()
    {
        OwnedMaterial = transform.Find("Material Owned").GetComponent<OwnedMaterial>();
        OwnedMaterial.UpdateNumber();
    }

    public void ShopContent(string type)
    {
        ItemShopList = new List<Item>();
        ItemShopDescription.gameObject.SetActive(false);
        if (type == "Weapon") AddWeapon();
        else if (type == "Boat") AddBoat();
        else if (type == "Stigmata") AddStigmata();
        else if (type == "Crew") AddCrew();
        FillShop();
        if (type == "Material") AddMaterials();
    }
    
    private void AddWeapon()
    {
        foreach (WeaponJSON weaponJson in PlayerStatsManager.JsonData.WeaponJSON)
        {
            Weapon weapon = new Weapon()
            {
                Level = 1,
                Name = weaponJson.Name,
                Rarity = weaponJson.Rarity
            };
            ItemShopList.Add(new Item(weaponJson.Name, weaponJson.Rarity, 1, weapon));
        }
    }
    
    private void AddBoat()
    {
        foreach (BoatJSON boatJson in PlayerStatsManager.JsonData.BoatJSON)
        {
            Boat boat = new Boat()
            {
                Level = 1,
                Name = boatJson.Name,
                Rarity = boatJson.Rarity
            };
            ItemShopList.Add(new Item(boat.Name, boat.Rarity, boat.Level, boat));
        }
    }

    private void AddStigmata()
    {
        foreach (StigmaJSON stigmaJson in PlayerStatsManager.JsonData.StigmaJSON)
        {
            Stigma stigma = new Stigma()
            {
                Level = 1,
                Name = stigmaJson.Name,
                Rarity = stigmaJson.Rarity
            };
            ItemShopList.Add(new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma));
        }
    }

    private void AddCrew()
    {
        foreach (CrewJSON crewJson in PlayerStatsManager.JsonData.CrewJSON)
        {
            Item item = null;
            switch (crewJson.Name)
            {
                case "Explorer":
                    Explorer explorer = new Explorer() { Level = 1, Rarity = crewJson.Rarity };
                    item = new Item(crewJson.Name, explorer.Rarity, explorer.Level, explorer);
                    break;
                case "Navigator":
                    Navigator navigator = new Navigator() { Level = 1, Rarity = crewJson.Rarity };
                    item = new Item(crewJson.Name, navigator.Rarity, navigator.Level, navigator);
                    break;
                case "Gunner":
                    Gunner gunner = new Gunner() { Level = 1, Rarity = crewJson.Rarity };
                    item = new Item(crewJson.Name, gunner.Rarity, gunner.Level, gunner);
                    break;
                case "Boatswain":
                    Boatswain boatswain = new Boatswain() { Level = 1, Rarity = crewJson.Rarity };
                    item = new Item(crewJson.Name, boatswain.Rarity, boatswain.Level, boatswain);
                    break;
            }
            ItemShopList.Add(item);
        }
    }

    private void AddMaterials()
    {
        foreach (Transform child in ContentParent)
        {
            Destroy(child.gameObject);
        }
        
        foreach (string mat in new[] {"Wood", "Steel", "Pure Water Drop"})
        {
            foreach (int num in new[] {1, 10, 100, 1000, 10000, 100000})
            {
                Material material = new Material(mat, num);
                GameObject newItem = Instantiate(ItemPrefab, ContentParent);
                ItemButton itemButton = newItem.GetComponent<ItemButton>();
                itemButton.InitMaterial(material);
                
                newItem.GetComponent<Button>().onClick.AddListener(() => ItemShopDescription.SetDescriptionMaterial(material, num));
            }
        }
    }





    private void AddItem(Item item)
    {
        GameObject newItem = Instantiate(ItemPrefab, ContentParent);

        ItemButton itemButton = newItem.GetComponent<ItemButton>();
        itemButton.InitItem(item);
        
        newItem.GetComponent<Button>().onClick.AddListener(() => ItemShopDescription.SetDescriptionItem(item));
    }

    private void FillShop()
    {
        foreach (Transform child in ContentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in ItemShopList)
        {
            AddItem(item);
        }
    }
}