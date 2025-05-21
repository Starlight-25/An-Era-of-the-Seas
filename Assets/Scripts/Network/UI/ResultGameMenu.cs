using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultGameMenu : MonoBehaviour
{
    public void DisconnectButtonClicked()
    {
        if (NetworkManager.Singleton.IsClient) NetworkManager.Singleton.Shutdown();
        SceneManager.LoadScene("MainMenu");
    }
}