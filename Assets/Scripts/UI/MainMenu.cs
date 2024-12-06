using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject AccountCanvas;
    public GameObject StartButton;
    public GameObject SoloButton;
    public GameObject MultiplayerButton;

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
}