using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class CustomNetworkHUD : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button serverButton;

    void Start()
    {
        // Associer les boutons à leurs actions
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
        serverButton.onClick.AddListener(StartServer);
    }

    void StartHost()
    {
        Debug.Log("Starting Host...");
        NetworkManager.Singleton.StartHost();
    }

    void StartClient()
    {
        Debug.Log("Starting Client...");
        NetworkManager.Singleton.StartClient();
    }

    void StartServer()
    {
        Debug.Log("Starting Server...");
        NetworkManager.Singleton.StartServer();
    }
}