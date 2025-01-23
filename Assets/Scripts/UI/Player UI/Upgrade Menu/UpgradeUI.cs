using System;
using UnityEngine;
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
    
    [SerializeField] private Button upgrade1XButton;
    [SerializeField] private Button upgrade2XButton;
    [SerializeField] private Button upgrade5XButton;
    [SerializeField] private Button upgrade10XButton;





    private void Start()
    {
        upgrade1XButton.onClick.AddListener(Upgrade1xClicked);
        upgrade2XButton.onClick.AddListener(Upgrade2xClicked);
        upgrade5XButton.onClick.AddListener(Upgrade5xClicked);
        upgrade10XButton.onClick.AddListener(Upgrade10xClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }

    public void ReturnButtonClicked()
    {
        UpgradeCanvas.SetActive(false);
        PreviousCanvas.SetActive(true);
    }





    public void Init(GameObject previousCanvas)
    {
        PreviousCanvas = previousCanvas;
        Item = null;
    }
    
    public void Init(GameObject previousCanvas, Item item)
    {
        PreviousCanvas = previousCanvas;
        Item = item;
    }





    private void Upgrade1xClicked()
    {
        
    }
    private void Upgrade2xClicked()
    {
        
    }
    private void Upgrade5xClicked()
    {
        
    }
    private void Upgrade10xClicked()
    {
        
    }
}
