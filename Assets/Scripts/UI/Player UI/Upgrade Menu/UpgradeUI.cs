using System;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeCanvas;
    private GameObject PreviousCanvas;
    [SerializeField] private PlayerDataManager PlayerDataManager;
    private Item Item;

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
    
    public void ReturnButtonClicked()
    {
        UpgradeCanvas.SetActive(false);
        PreviousCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }
}
