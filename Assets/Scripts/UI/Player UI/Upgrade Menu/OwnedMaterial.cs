using System;
using TMPro;
using UnityEngine;

public class OwnedMaterial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinNumber;
    [SerializeField] private TextMeshProUGUI PWDNumber;
    [SerializeField] private TextMeshProUGUI WoodNumber;
    [SerializeField] private TextMeshProUGUI StealNumber;
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
        StealNumber.text = Materials.Steal.ToString();
    }
}
