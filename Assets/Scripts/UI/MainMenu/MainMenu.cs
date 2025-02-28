using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject CreditsCanvas;
    [SerializeField] private GameObject PseudoCanvas;
    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject SoloButton;
    [SerializeField] private GameObject MultiplayerButton;
    [SerializeField] private GameObject MultiplayerCanvas;

    private string savepath;


    
    
    
    
    
    
    
    
    private void Awake()
    {
        savepath = Application.persistentDataPath + "/playerData.json";
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
        SceneManager.LoadScene("SoloGame");
    }

    public void MultiplayerButtonClicked()
    {
        SceneManager.LoadScene("Network");
        MainMenuCanvas.SetActive(false);
        MultiplayerCanvas.SetActive(true);
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