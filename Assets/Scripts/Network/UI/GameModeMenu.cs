using System;
using Unity.Netcode;
using UnityEngine;

public class GameModeMenu : MonoBehaviour
{
    [SerializeField] private GameObject DefaultUI;
    [SerializeField] private GameObject gameModeMenuGameObject;
    private GameManager GameManager;

    
    
    
    
    private void Start()
    {
        GameManager = FindFirstObjectByType<GameManager>();
    }

    
    
    

    public void TreasureHuntButtonClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DefaultUI.SetActive(true);
        gameModeMenuGameObject.SetActive(false);
        GameManager.StartTreasureHuntGame();
    }

    
    
    
    
    public void BoatRaceButtonClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DefaultUI.SetActive(true);
        gameModeMenuGameObject.SetActive(false);
        GameManager.StartBoatRaceGame();
    }
}