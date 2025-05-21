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
    private Material Material;


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
        Material = null;
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


    public void SetDescriptionMaterial(Material material, int num)
    {
        transform.gameObject.SetActive(true);
        Material = material;
        Item = null;
        Name.text = material.Name;
        RaritySprite.sprite = material.RaritySprite;
        ItemSprite.sprite = material.MaterialSprite;
        MaterialsNeeded.text = $"Coins: {num * 2}";
    }



    public void BuyButtonClicked()
    {
        Materials materials = PlayerStatsManager.PlayerDataManager.PlayerData.Inventory.Backpack.Materials;
        if (Item is null)
        {
            if (Material.Name == "Pure Water Drop" && materials.Coins >= 5 * Material.Number)
                PlayerStatsManager.UpdateMaterial(-5 * Material.Number, Material.Number);
            else if (Material.Name == "Wood" && materials.Coins >= 2 * Material.Number)
                PlayerStatsManager.UpdateMaterial(-2 * Material.Number, 0, Material.Number);
            else if (Material.Name == "Steel" && materials.Coins >= 2 * Material.Number)
                PlayerStatsManager.UpdateMaterial(-2 * Material.Number, 0, 0, Material.Number);
        }
        else
        {
            (int coin, int pwd) = GetNecessaryMaterial();
            if (PlayerStatsManager.AddItem(Item.Object) && materials.Coins >= coin && materials.PureWaterDrop >= pwd)
            {
                PlayerStatsManager.UpdateMaterial(-coin, -pwd);
            }
        }    
        transform.parent.Find("Material Owned").GetComponent<OwnedMaterial>().UpdateNumber();
    }
}
