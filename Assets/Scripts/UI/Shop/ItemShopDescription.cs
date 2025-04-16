using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopDescription : MonoBehaviour
{
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    private JsonData JsonData;
    private TextMeshProUGUI Name;
    private Image RaritySprite;
    private Image ItemSprite;
    private TextMeshProUGUI MaterialsNeeded;

    private Item Item;


    private void Awake()
    {
        JsonData = PlayerStatsManager.JsonData;
        Name = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        RaritySprite = transform.Find("RaritySprite").GetComponent<Image>();
        ItemSprite = transform.Find("Icon").GetComponent<Image>();
        MaterialsNeeded = transform.Find("Materials").GetComponent<TextMeshProUGUI>();
    }


    public void SetDescriptionItem(Item item)
    {
        transform.gameObject.SetActive(true);
        Item = item;
        Name.text = Item.Name;
        RaritySprite.sprite = Item.RaritySprite;
        ItemSprite.sprite = Item.ItemSprite;
        MaterialsNeeded.text = "";
        (int coin, int pwd) = GetNecessaryMaterial();
        MaterialsNeeded.text += $"Coins: {coin}";
        if (pwd != 0) MaterialsNeeded.text += $"\nPure Water Drop: {pwd}";
    }

    private (int coin, int pwd) GetNecessaryMaterial()
    {
        (int coin, int pwd) = (0, 0);
        if (Item.Object is Stigma)
        {
            StigmaJSON stigmaCsv = JsonData.GetStigma(Item.Name);
            (coin, pwd) = (stigmaCsv.PriceCoin, stigmaCsv.PricePWD);
        }
        else if (Item.Object is Weapon)
        {
            WeaponJSON weaponJson = JsonData.GetWeapon(Item.Name);
            coin = weaponJson.Price;
        }
        else if (Item.Object is Boat)
        {
            BoatJSON boatJson = JsonData.GetBoat(Item.Name);
            coin = boatJson.Price;
        }
        else if (Item.Object is CrewMember)
        {
            CrewJSON crewJson = JsonData.GetCrew(Item.Name, Item.Rarity);
            coin = crewJson.Price;
        }
        return (coin, pwd);
    }





    public void BuyButtonClicked()
    {
        (int coin, int pwd) = GetNecessaryMaterial();
        Materials materials = PlayerStatsManager.PlayerDataManager.PlayerData.Inventory.Backpack.Materials;
        if (PlayerStatsManager.AddItem(Item.Object) && materials.Coins >= coin && materials.PureWaterDrop >= pwd)
        {
            materials.Coins -= coin;
            materials.PureWaterDrop -= pwd;
            PlayerStatsManager.PlayerDataManager.SavePlayerData();
            PlayerStatsManager.UpdatePlayerStats();
            PlayerStatsManager.UpdateBoatStats();
            transform.parent.Find("Material Owned").GetComponent<OwnedMaterial>().UpdateNumber();
        }
    }
}
