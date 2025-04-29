using Unity.Netcode;
using UnityEngine;

public class ResultGameMenu : MonoBehaviour
{
    public void DisconnectButtonClicked()
    {
        if (NetworkManager.Singleton.IsClient) NetworkManager.Singleton.Shutdown();
    }
}