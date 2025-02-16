using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUICanvas;
    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private GameObject CharacterCanvas;
    [SerializeField] private GameObject BackpackCanvas;
    [SerializeField] private GameObject MapCanvas;
    [SerializeField] private GameObject CreditsCanvas;

    [SerializeField] private PlayerDataManager PlayerDataManager; 

    public void ReturnButtonClicked()
    {
        SettingsCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }

    public void CharacterButtonClicked()
    {
        CharacterCanvas.transform.GetComponent<CharacterMenu>().SetPreviousCanvas(SettingsCanvas);
        SettingsCanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
    }
    
    public void BackpackButtonClicked()
    {
        BackpackCanvas.transform.GetComponent<BackpackMenuManager>().SetPreviousCanvas(SettingsCanvas);
        SettingsCanvas.SetActive(false);
        BackpackCanvas.SetActive(true);
    }

    public void MapButtonClicked()
    {
        MapCanvas.transform.GetComponent<MapMenu>().SetPreviousCanvas(SettingsCanvas);
        SettingsCanvas.SetActive(false);
        MapCanvas.SetActive(true);
    }

    public void CreditsButtonClicked()
    {
        SettingsCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
    }

    public void QuitButtonClicked()
    {
        PlayerDataManager.SavePlayerData();
        SettingsCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }
}
