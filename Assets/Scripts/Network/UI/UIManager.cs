using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject DefaultUI;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject ResultGameMenu;
    [SerializeField] private GameObject GameModeMenu;
    
    
    
    
    
    
    public void DisplayResult(string msg)
    {
        SetCursorStatus();
        ResultGameMenu.SetActive(true);
        DefaultUI.SetActive(false);
        SettingsMenu.SetActive(false);
        ResultGameMenu.transform.Find("Result Text").GetComponent<TextMeshProUGUI>().text = msg;
    }





    public void DisplayGameModeMenu()
    {
        SetCursorStatus();
        GameModeMenu.SetActive(true);
        ResultGameMenu.SetActive(false);
        DefaultUI.SetActive(false);
        SettingsMenu.SetActive(false);
    }
    
    
    
    
    
    
    
    private void SetCursorStatus(bool visible = true)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }
}