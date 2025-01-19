using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Item
{
    public string Name;
    public string Rarity;
    public int Level;
    public object Object;
    public Sprite Icon;

    public Item(string name, string rarity, int level, object obj)
    {
        Name = name;
        Rarity = rarity;
        Level = level;
        Object = obj;
        Icon = null;
    }
}

public class Material
{
    public string Name;
    public int Number;
    public Sprite Icon;

    public Material(string name, int number)
    {
        Name = name;
        Number = number;
        Icon = null;
    }
}





public class InventoryManager : MonoBehaviour
{
    public PlayerDataManager PlayerDataManager;
    
    public GameObject ItemPrefab;
    public Transform ContentParent;

    private List<Item> ItemList;
    private List<Material> MaterialList;

    public ItemDescription ItemDescription;
    
    
    
    private Backpack Backpack;
    private void BackpackInit()
    {
        Backpack = PlayerDataManager.PlayerData.Inventory.Backpack;
    }









    public void InitMaterialInventory()
    {
        ItemList = new List<Item>();
        MaterialList = new List<Material>();
        MaterialList.Add(new Material("Coins", Backpack.Materials.Coins));
        MaterialList.Add(new Material("Pure Water Drop", Backpack.Materials.PureWaterDrop));
        MaterialList.Add(new Material("Wood", Backpack.Materials.Wood));
        MaterialList.Add(new Material("Steal", Backpack.Materials.Steal));
        FillInventory();
    }
    
    
    
    
    
    public void InitWeaponInventory()
    {
        ItemList = new List<Item>();
        MaterialList = new List<Material>();
        foreach (Weapon weapon in Backpack.Weapons)
        {
            ItemList.Add(new Item(weapon.Name, weapon.Rarity, weapon.Level, weapon));
        }
        FillInventory();
    }




    
    public void InitStigmaInventory()
    {
        ItemList = new List<Item>();
        MaterialList = new List<Material>();
        foreach (Stigma stigma in Backpack.Stigmata)
        {
            ItemList.Add(new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma));
        }
        FillInventory();
    }




    public void InitBoatInventory()
    {
        ItemList = new List<Item>();
        MaterialList = new List<Material>();
        foreach (Boat boat in Backpack.Boats)
        {
            ItemList.Add(new Item(boat.Name, boat.Rarity, boat.Level, boat));
        }
        FillInventory();
    }


    
    
    
    public void InitCrewInventory()
    {
        ItemList = new List<Item>();
        MaterialList = new List<Material>();
        foreach (Explorer explorer in Backpack.Crew.Explorer)
        {
            ItemList.Add(new Item("Explorer", explorer.Rarity, explorer.Level, explorer));
        }
        foreach (Navigator navigator in Backpack.Crew.Navigator)
        {
            ItemList.Add(new Item("Navigator", navigator.Rarity, navigator.Level, navigator));
        }
        foreach (Gunner gunner in Backpack.Crew.Gunner)
        {
            ItemList.Add(new Item("Gunner", gunner.Rarity, gunner.Level, gunner));
        }
        foreach (Boatswain boatswain in Backpack.Crew.Boatswain)
        {
            ItemList.Add(new Item("Boatswain", boatswain.Rarity, boatswain.Level, boatswain));
        }
        FillInventory();
    }
    
    
    
    
    
    
    
    
    
    
    private void AddItem(Item item)
    {
        GameObject newItem = Instantiate(ItemPrefab, ContentParent);

        ItemButton itemButton = newItem.GetComponent<ItemButton>();
        itemButton.InitItem(item);
        
        newItem.GetComponent<Button>().onClick.AddListener(() => ItemDescription.SetDescriptionItem(item));
    }

    private void AddMaterial(Material material)
    {
        GameObject newItem = Instantiate(ItemPrefab, ContentParent);

        ItemButton itemButton = newItem.GetComponent<ItemButton>();
        itemButton.InitMaterial(material);
            
        newItem.GetComponent<Button>().onClick.AddListener(() => ItemDescription.SetDescriptionMaterial(material));
    }
    
    
    
    
    
    public void FillInventory()
    {
        foreach (Transform child in ContentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in ItemList)
        {
            AddItem(item);
        }
        
        if (MaterialList != null)
        {
            foreach (Material material in MaterialList)
            {
                AddMaterial(material);
            }
        }    
    }

    
    
    
    
    
    
    
    
    
    private void Start()
    {
        BackpackInit();
    }
}
