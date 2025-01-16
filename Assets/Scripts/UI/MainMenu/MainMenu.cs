using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Windows;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject PseudoCanvas;
    public GameObject StartButton;
    public GameObject SoloButton;
    public GameObject MultiplayerButton;

    private string savepath;


    
    
    
    
    
    
    
    
    private void Awake()
    {
        savepath = Application.persistentDataPath + "/playerData.json";
        Debug.Log(savepath);
    }

    private void OnEnable()
    {
        //Debug.Log(File.Exists(savepath));
        if (!File.Exists(savepath))
        {
            SoloButton.SetActive(false);
            MultiplayerButton.SetActive(false);
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
            SoloButton.SetActive(true);
            MultiplayerButton.SetActive(true);
        }
    }


    
    
    
    
    
    
    
    
    public void StartButtonClicked()
    {
        MainMenuCanvas.SetActive(false);
        PseudoCanvas.SetActive(true);
    }
    public void SoloButtonClicked()
    {
        SceneManager.LoadScene("PlayerUI");
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