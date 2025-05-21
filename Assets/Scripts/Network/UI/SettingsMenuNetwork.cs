using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        DestroyBoat();
        ReturnButtonClicked();
        if (NetworkManager.Singleton.IsClient) NetworkManager.Singleton.Shutdown();
        SceneManager.LoadScene("MainMenu");
    }

    private void DestroyBoat()
    {
        foreach (BoatMovementNetwork boatMovementNetwork in FindObjectsByType<BoatMovementNetwork>(FindObjectsSortMode.None))
        {
            GameObject boat = boatMovementNetwork.gameObject;
            Destroy(boat);
        }
    }
    
    
    
    
    
    private void SetCursorStatus(bool visible = true)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }
}