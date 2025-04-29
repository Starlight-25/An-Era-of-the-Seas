using System;
using Unity.Netcode;
using UnityEngine;

public class GameModeMenu : MonoBehaviour
{
    private GameManager GameManager;

    
    
    
    
    private void Start()
    {
        GameManager = FindFirstObjectByType<GameManager>();
    }

    
    
    

    public void TreasureHuntButtonClicked()
    {
        GameManager.StartTreasureHuntGame();
    }

    
    
    
    
    public void BoatRaceButtonClicked()
    {
        GameManager.StartBoatRaceGame();
    }
}