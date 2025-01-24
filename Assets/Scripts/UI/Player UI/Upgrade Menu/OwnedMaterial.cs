using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class OwnedMaterial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinNumber;
    [SerializeField] private TextMeshProUGUI PWDNumber;
    [SerializeField] private TextMeshProUGUI WoodNumber;
    [SerializeField] private TextMeshProUGUI SteelNumber;
    public PlayerDataManager PlayerDataManager;


    
    
    
    private void Start()
    {
        UpdateNumber();
    }

    
    
    
    
    public void UpdateNumber()
    {
        Materials Materials = PlayerDataManager.PlayerData.Inventory.Backpack.Materials;
        CoinNumber.text = Materials.Coins.ToString();
        PWDNumber.text = Materials.PureWaterDrop.ToString();
        WoodNumber.text = Materials.Wood.ToString();
        SteelNumber.text = Materials.Steel.ToString();
    }
}
