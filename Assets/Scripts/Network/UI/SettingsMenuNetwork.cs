using System;
using Unity.Netcode;
using UnityEngine;

public class SettingsMenuNetwork : MonoBehaviour
{
    [SerializeField] private GameObject DefaultUI;
    [SerializeField] private GameObject SettingsMenu;


    
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }

    
    
    
    
    public void ReturnButtonClicked()
    {
        SetCursorStatus(false);

        DefaultUI.SetActive(true);
        SettingsMenu.SetActive(false);
    }






    public void DisconnectButtonClicked()
    {
        ReturnButtonClicked();
        if (NetworkManager.Singleton.IsClient) NetworkManager.Singleton.Shutdown();
    }
    
    
    
    
    
    private void SetCursorStatus(bool visible = true)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
        Debug.Log($"SettingsMenu : {visible}");
    }
}