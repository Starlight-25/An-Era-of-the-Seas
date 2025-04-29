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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ResultGameMenu.SetActive(true);
        DefaultUI.SetActive(false);
        SettingsMenu.SetActive(false);
        ResultGameMenu.transform.Find("Result Text").GetComponent<TextMeshProUGUI>().text = msg;
    }





    public void DisplayGameModeMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameModeMenu.SetActive(true);
        ResultGameMenu.SetActive(false);
        DefaultUI.SetActive(false);
        SettingsMenu.SetActive(false);
    }
}