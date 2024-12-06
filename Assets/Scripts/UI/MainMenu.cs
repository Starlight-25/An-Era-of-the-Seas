using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject AccountCanvas;
    public GameObject StartButton;
    public GameObject SoloButton;
    public GameObject MultiplayerButton;

    private string Pseudo;
    
    
    
    
    
    
    
    
    
    private void Start()
    {
        AccountMenu.OnPseudoChanged += HandlePseudoChanged;
    }

    private void Update()
    {
        if (string.IsNullOrEmpty(Pseudo))
        {
            SoloButton.SetActive(false);
            MultiplayerButton.SetActive(false);
            StartButton.SetActive(true);
        }
        else if (!string.IsNullOrEmpty(Pseudo))
        {
            StartButton.SetActive(false);
            SoloButton.SetActive(true);
            MultiplayerButton.SetActive(true);
        }
    }


    
    
    
    
    
    
    
    
    public void StartButtonClicked()
    {
        MainMenuCanvas.SetActive(false);
        AccountCanvas.SetActive(true);
    }
    public void SoloButtonClicked()
    {
        Debug.Log("Solo Mode");
        //SceneManager.LoadScene("Solo mode");
    }

    public void MultiplayerButtonClicked()
    {
        Debug.Log("Multiplayer mode");
        //SceneManager.LoadScene("Solo mode");
    }
    
    public void CreditsButtonClicked()
    {
        MainMenuCanvas.SetActive(false); 
        CreditsCanvas.SetActive(true);
    }
    
    public void QuitButtonClicked()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
    
    
    
    
    
    
    
    
    
    
    private void HandlePseudoChanged(string pseudo)
    {
        Pseudo = pseudo;
        Debug.Log($"Pseudo : {Pseudo}");
    }
}