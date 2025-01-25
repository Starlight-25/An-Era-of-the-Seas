using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwitchHandle : MonoBehaviour
{
    [SerializeField] private PlayerDataManager PlayerDataManager;
    [SerializeField] private PlayerStatsManager PlayerStatsManager;

    [SerializeField] private GameObject CharacterCanvas;
    private GameObject CurrentElements;
    [SerializeField] private CharacterMenu CharacterMenu;
    [SerializeField] private GameObject SwitchCanvas;

    private Item Item;

    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private Transform ContentParent;

    private List<Item> ItemList;
    private Backpack Backpack;
    private Equipped Equipped;
    
    
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void ReturnButtonClicked()
    {
        SwitchCanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
        switch (CurrentElements.name)
        {
            case "Weapon Elements":
                CharacterMenu.WeaponButtonClicked();
                break;
            case "Stigmata Elements":
                CharacterMenu.StigmataButtonClicked();
                break;
            case "Boat Elements":
                CharacterMenu.BoatButtonClicked();
                break;
            case "Crew Members Elements":
                CharacterMenu.CrewMembersButtonClicked();
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }

    
    
    
    
    public void InitSwitchMenu(Item item, GameObject currentElements)
    {
        CharacterCanvas.SetActive(false);
        SwitchCanvas.SetActive(true);
        
        Backpack = PlayerDataManager.PlayerData.Inventory.Backpack;
        Equipped = PlayerDataManager.PlayerData.Inventory.Equipped;
        
        CurrentElements = currentElements;
        Item = item;
        ItemList = new List<Item>();
        
        InitListItem();
        FillSwitchScrollView();
    }

    public void InitSwitchMenu(string ItemType, GameObject currentElements)
    {
        CharacterCanvas.SetActive(false);
        SwitchCanvas.SetActive(true);
        
        Backpack = PlayerDataManager.PlayerData.Inventory.Backpack;
        Equipped = PlayerDataManager.PlayerData.Inventory.Equipped;
        
        CurrentElements = currentElements;
        Item = null;
        ItemList = new List<Item>();
        
        InitListItem(ItemType);
        FillSwitchScrollView();
    }

    
    
    
    
    private void InitListItem()
    {
        if (Item.Object is Weapon)
        {
            foreach (Weapon weapon in Backpack.Weapons)
            {
                ItemList.Add(new Item(weapon.Name, weapon.Rarity, weapon.Level, weapon));
            }
        }
        else if (Item.Object is Stigma)
        {
            foreach (Stigma stigma in Backpack.Stigmata)
            {
                ItemList.Add(new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma));
            }
        }
        else if (Item.Object is Boat)
        {
            foreach (Boat boat in Backpack.Boats)
            {
                ItemList.Add(new Item(boat.Name, boat.Rarity, boat.Level, boat));
            }
        }
        else if (Item.Object is Explorer)
        {
            foreach (Explorer explorer in Backpack.Crew.Explorer)
            {
                ItemList.Add(new Item("Explorer", explorer.Rarity, explorer.Level, explorer));
            }
        }
        else if (Item.Object is Navigator)
        {
            foreach (Navigator navigator in Backpack.Crew.Navigator)
            {
                ItemList.Add(new Item("Navigator", navigator.Rarity, navigator.Level, navigator));
            }
        }
        else if (Item.Object is Gunner)
        {
            foreach (Gunner gunner in Backpack.Crew.Gunner)
            {
                ItemList.Add(new Item("Gunner", gunner.Rarity, gunner.Level, gunner));
            }
        }
        else if (Item.Object is Boatswain)
        {
            foreach (Boatswain boatswain in Backpack.Crew.Boatswain)
            {
                ItemList.Add(new Item("Boatswain", boatswain.Rarity, boatswain.Level, boatswain));
            }
        }
    }





    private void InitListItem(string itemType)
    {
        if (itemType == "Stigma")
        {
            foreach (Stigma stigma in Backpack.Stigmata)
            {
                ItemList.Add(new Item(stigma.Name, stigma.Rarity, stigma.Level, stigma));
            }
        }
        else if (itemType == "Explorer")
        {
            foreach (Explorer explorer in Backpack.Crew.Explorer)
            {
                ItemList.Add(new Item("Explorer", explorer.Rarity, explorer.Level, explorer));
            }
        }
        else if (itemType == "Navigator")
        {
            foreach (Navigator navigator in Backpack.Crew.Navigator)
            {
                ItemList.Add(new Item("Navigator", navigator.Rarity, navigator.Level, navigator));
            }
        }
        else if (itemType == "Gunner")
        {
            foreach (Gunner gunner in Backpack.Crew.Gunner)
            {
                ItemList.Add(new Item("Gunner", gunner.Rarity, gunner.Level, gunner));
            }
        }
        else if (itemType == "Boatswain")
        {
            foreach (Boatswain boatswain in Backpack.Crew.Boatswain)
            {
                ItemList.Add(new Item("Boatswain", boatswain.Rarity, boatswain.Level, boatswain));
            }
        }
    }




    private void FillSwitchScrollView()
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
    
    
    
    
    
    private void AddItem(Item item)
    {
        GameObject newItem = Instantiate(ItemPrefab, ContentParent);

        ItemButton itemButton = newItem.GetComponent<ItemButton>();
        itemButton.InitItem(item);
        
        newItem.GetComponent<Button>().onClick.AddListener(() => SwitchItem(item));
    }



    

    private void SwitchItem(Item item)
    {
        switch (CurrentElements.name)
        {
            case "Weapon Elements":
                Backpack.Weapons.Remove((Weapon)item.Object);
                Backpack.Weapons.Add((Weapon)Item.Object);
                Backpack.Weapons.Sort((x, y) => x.Level.CompareTo(y.Level));
                Equipped.Weapon = (Weapon)item.Object;
                break;
            case "Stigmata Elements":
                Backpack.Stigmata.Remove((Stigma)item.Object);
                if (Item is not null)
                {
                    Backpack.Stigmata.Add((Stigma)Item.Object);
                    Backpack.Stigmata.Sort((x, y) => x.Level.CompareTo(y.Level));
                    Equipped.Stigmata[Equipped.Stigmata.IndexOf((Stigma)Item.Object)] = (Stigma)item.Object;
                }
                else Equipped.Stigmata[Equipped.Stigmata.IndexOf(null)] = (Stigma)item.Object;
                break;
            case "Boat Elements":
                Backpack.Boats.Remove((Boat)item.Object);
                Backpack.Boats.Add((Boat)Item.Object);
                Backpack.Boats.Sort((x, y) => x.Level.CompareTo(y.Level));
                Equipped.Boat = (Boat)item.Object;
                
                Backpack.Crew.Explorer.AddRange(Equipped.Crew.Explorer);
                Backpack.Crew.Explorer.Sort((x, y) => x.Level.CompareTo(y.Level));
                Equipped.Crew.Explorer = new List<Explorer>();
                Backpack.Crew.Navigator.AddRange(Equipped.Crew.Navigator);
                Backpack.Crew.Navigator.Sort((x, y) => x.Level.CompareTo(y.Level));
                Equipped.Crew.Navigator = new List<Navigator>();
                Backpack.Crew.Gunner.AddRange(Equipped.Crew.Gunner);
                Backpack.Crew.Gunner.Sort((x, y) => x.Level.CompareTo(y.Level));
                Equipped.Crew.Gunner = new List<Gunner>();
                Backpack.Crew.Boatswain.AddRange(Equipped.Crew.Boatswain);
                Backpack.Crew.Boatswain.Sort((x, y) => x.Level.CompareTo(y.Level));
                Equipped.Crew.Boatswain = new List<Boatswain>();
                break;
            case "Crew Members Elements":
                if (item.Object is Explorer explorer)
                {
                    Backpack.Crew.Explorer.Remove(explorer);
                    if (Item is not null)
                    {
                        Backpack.Crew.Explorer.Add((Explorer)Item.Object);
                        Backpack.Crew.Explorer.Sort((x, y) => x.Level.CompareTo(y.Level));
                        Equipped.Crew.Explorer[Equipped.Crew.Explorer.IndexOf((Explorer)Item.Object)] = explorer;
                    }
                    else Equipped.Crew.Explorer.Add(explorer);
                }
                else if (item.Object is Navigator navigator)
                {
                    Backpack.Crew.Navigator.Remove(navigator);
                    if (Item is not null)
                    {
                        Backpack.Crew.Navigator.Add((Navigator)Item.Object);
                        Backpack.Crew.Navigator.Sort((x, y) => x.Level.CompareTo(y.Level));
                        Equipped.Crew.Navigator[Equipped.Crew.Navigator.IndexOf((Navigator)Item.Object)] = navigator;
                    }
                    else Equipped.Crew.Navigator.Add(navigator);
                }
                else if (item.Object is Gunner gunner)
                {
                    Backpack.Crew.Gunner.Remove(gunner);
                    if (Item is not null)
                    {
                        Backpack.Crew.Gunner.Add((Gunner)Item.Object);
                        Backpack.Crew.Gunner.Sort((x, y) => x.Level.CompareTo(y.Level));
                        Equipped.Crew.Gunner[Equipped.Crew.Gunner.IndexOf((Gunner)Item.Object)] = gunner;
                    }
                    else Equipped.Crew.Gunner.Add(gunner);
                }
                else if (item.Object is Boatswain boatswain)
                {
                    Backpack.Crew.Boatswain.Remove(boatswain);
                    if (Item is not null)
                    {
                        Backpack.Crew.Boatswain.Add((Boatswain)Item.Object);
                        Backpack.Crew.Boatswain.Sort((x, y) => x.Level.CompareTo(y.Level));
                        Equipped.Crew.Boatswain[Equipped.Crew.Boatswain.IndexOf((Boatswain)Item.Object)] = boatswain;
                    }
                    else Equipped.Crew.Boatswain.Add(boatswain);
                }
                break;
        }
        PlayerDataManager.SavePlayerData();
        PlayerStatsManager.UpdatePlayerStats();
        PlayerStatsManager.UpdateBoatStats();
        ReturnButtonClicked();
    }
}
