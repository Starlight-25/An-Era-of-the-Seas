using Unity.Netcode;
using UnityEngine;

public class SettingsMenuNetwork : MonoBehaviour
{
    [SerializeField] private GameObject DefaultUI;
    [SerializeField] private GameObject SettingsMenu;
    
    
    
    
    
    public void ReturnButtonClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        DefaultUI.SetActive(true);
        SettingsMenu.SetActive(false);
    }






    public void DisconnectButtonClicked()
    {
        ReturnButtonClicked();
        if (NetworkManager.Singleton.IsClient) NetworkManager.Singleton.Shutdown();
    }
}