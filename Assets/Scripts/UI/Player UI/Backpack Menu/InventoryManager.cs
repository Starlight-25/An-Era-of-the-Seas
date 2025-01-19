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

    public Item(string name, string rarity, int level, object obj, Sprite icon)
    {
        Name = name;
        Rarity = rarity;
        Level = level;
        Object = obj;
        Icon = icon;
    }
}





public class InventoryManager : MonoBehaviour
{
    public PlayerDataManager PlayerDataManager;
    
    public GameObject ItemPrefab;
    public Transform ContentParent;

    private List<Item> ItemList;

    public ItemDescription ItemDescription;
    
    
    
    private Backpack Backpack;
    private void BackpackInit()
    {
        Backpack = PlayerDataManager.PlayerData.Inventory.Backpack;
    }
    
    
    
    
    
    
    
    
    
    
    public void InitWeaponInventory()
    {
        ItemList = new List<Item>();
        foreach (Weapon weapon in Backpack.Weapons)
        {
            ItemList.Add(new Item(weapon.Name, weapon.Rarity, weapon.Level, weapon, null));
        }
        FillInventory();
    }






    public void InitStigmaInventory()
    {
        ItemList = new List<Item>();
        foreach (Stigma stigma in Backpack.Stigmata)
        {
            ItemList.Add(new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma, null));
        }
        FillInventory();
    }




    public void InitBoatInventory()
    {
        ItemList = new List<Item>();
        foreach (Boat boat in Backpack.Boats)
        {
            ItemList.Add(new Item(boat.Name, boat.Rarity, boat.Level, boat, null));
        }
        FillInventory();
    }


    public void InitCrewInventory()
    {
        ItemList = new List<Item>();
        foreach (Explorer explorer in Backpack.Crew.Explorer)
        {
            ItemList.Add(new Item("Explorer", explorer.Rarity, explorer.Level, explorer, null));
        }
        foreach (Navigator navigator in Backpack.Crew.Navigator)
        {
            ItemList.Add(new Item("Navigator", navigator.Rarity, navigator.Level, navigator, null));
        }
        foreach (Gunner gunner in Backpack.Crew.Gunner)
        {
            ItemList.Add(new Item("Gunner", gunner.Rarity, gunner.Level, gunner, null));
        }
        foreach (Boatswain boatswain in Backpack.Crew.Boatswain)
        {
            ItemList.Add(new Item("Boatswain", boatswain.Rarity, boatswain.Level, boatswain, null));
        }
        FillInventory();
    }
    
    
    
    
    
    
    
    
    private void AddItem(Item item)
    {
        GameObject newItem = Instantiate(ItemPrefab, ContentParent);

        ItemButton itemButton = newItem.GetComponent<ItemButton>();
        itemButton.Init(item);
        
        newItem.GetComponent<Button>().onClick.AddListener(() => ItemDescription.SetDescription(item));
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
    }

    
    
    
    
    
    
    
    
    
    private void Start()
    {
        BackpackInit();
    }
}
