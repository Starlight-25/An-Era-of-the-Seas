using System;
using Unity.Netcode;
using UnityEngine;

public class GameModeMenu : MonoBehaviour
{
    [SerializeField] private GameObject DefaultUI;
    [SerializeField] private GameObject gameModeMenuGameObject;
    private GameManager GameManager;


    private void Update()
    {
        SetCursorStatus();
    }

    private void Start()
    {
        GameManager = FindFirstObjectByType<GameManager>();
    }

    
    
    

    public void TreasureHuntButtonClicked()
    {
        SetCursorStatus(false);
        DefaultUI.SetActive(true);
        gameModeMenuGameObject.SetActive(false);
        GameManager.StartTreasureHuntGame();
    }

    
    
    
    
    public void BoatRaceButtonClicked()
    { 
        SetCursorStatus(false);
        DefaultUI.SetActive(true);
        gameModeMenuGameObject.SetActive(false);
        GameManager.StartBoatRaceGame();
    }
    
    
    
    
    
    private void SetCursorStatus(bool visible = true)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }
}