using System;
using UnityEngine;

public class DefaultUINetwork : MonoBehaviour
{
    [SerializeField] private GameObject DefaultUI;
    [SerializeField] private GameObject SettingsMenu;


    
    
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SettingsButtonClicked();
    }

    
    
    
    
    public void SettingsButtonClicked()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SettingsMenu.SetActive(true);
        DefaultUI.SetActive(false);
    }
}