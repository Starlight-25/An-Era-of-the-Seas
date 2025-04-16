using UnityEngine;
using UnityEngine.SceneManagement;
//using Unity.Netcode;
using UnityEngine.UI;

public class MultiplayerMenu : MonoBehaviour
{
    [SerializeField] private GameObject MultiplayerCanvas;
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ClientButton;

    void Start()
    {
        HostButton.onClick.AddListener(StartHost);
        ClientButton.onClick.AddListener(StartClient);
        //fonction pour handle si connection ou deconnexion
        //NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        //NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    void OnDestroy()
    {
        // Se désabonner pour éviter les erreurs de mémoire
        //if (NetworkManager.Singleton == null) return;
//
        //NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        //NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
    }
    
    
    
    
    
    void StartHost()
    {
        Debug.Log("Starting Host...");
        //NetworkManager.Singleton.StartHost();
        //SceneManager.LoadScene("Multipayer");
    }

    void StartClient()
    {
        Debug.Log("Starting Client...");
        //NetworkManager.Singleton.StartClient();
        //SceneManager.LoadScene("Multipayer");
    }
    
    //NetworkManager.Singleton.Shutdown();
    //pour se deconnecter

    public void ReturnButtonClicked()
    {
        MultiplayerCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }
    
    
    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} connected.");
        //if (clientId == NetworkManager.Singleton.LocalClientId)
        //{
        //    Debug.Log("You have successfully connected to the server!");
        //    NetworkCanvas.SetActive(false);
        //}
    }

    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} disconnected.");
        //if (clientId == NetworkManager.Singleton.LocalClientId)
        //{
        //    Debug.Log("You have been disconnected from the server.");
        //    NetworkCanvas.SetActive(true);
        //}
    }
    
}
