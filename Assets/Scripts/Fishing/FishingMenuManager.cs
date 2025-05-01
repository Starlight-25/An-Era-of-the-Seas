using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FishingMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUI;
    [SerializeField] private GameObject FishingMenu;
    [SerializeField] private RectTransform FishesParent;
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    [SerializeField] private TextMeshProUGUI NumberFish;
    private GameObject[] FishPrefabs;
    private int numberToSpawn = 6;

    
    
    
    private void Awake()
    {
        FishPrefabs = Resources.LoadAll<GameObject>("Fish/Prefab");
    }

    
    
    

    private void Start()
    {
        NumberFish.text = PlayerStatsManager.PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Fish.ToString();
        StartFishing();
    }

    
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }

    
    
    
    
    public void ReturnButtonClicked()
    {
        PlayerUI.SetActive(true);
        FishingMenu.SetActive(false);
    }





    public void ShowFishingMenu()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FishingMenu.SetActive(true);
        PlayerUI.SetActive(false);
    }






    public void StartFishing()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            SpawnFishRandom();
        }
    }

    private void SpawnFishRandom()
    {
        GameObject newFish = Instantiate(FishPrefabs[Random.Range(0, 3)], FishesParent);
        RectTransform rectTransform = newFish.GetComponent<RectTransform>();

        (float x, float y) = (Random.Range(0, FishesParent.rect.width),
            Random.Range(100, FishesParent.rect.height - 100));

        rectTransform.anchoredPosition = new Vector2(x, y);
    }




    public void AddFishToInventory()
    {
        PlayerStatsManager.UpdateFish(1);
        NumberFish.text = PlayerStatsManager.PlayerDataManager.PlayerData.Inventory.Backpack.Materials.Fish.ToString();
        SpawnFishRandom();
    }
}