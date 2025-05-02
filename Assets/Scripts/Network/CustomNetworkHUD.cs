using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomNetworkHUD : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private GameObject NetworkCanvas;
    
    
    
    
    
    void Start()
    {
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
        //fonction pour handle si connection ou deconnexion
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    
    
    
    
    void OnDestroy()
    {
        // Se désabonner pour éviter les erreurs de mémoire
        if (NetworkManager.Singleton == null) return;

        NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
    }

    
    
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
        if (!Cursor.visible) SetCursorStatus();
    }


    
    
    
    void StartHost()
    {
        Debug.Log("Starting Host...");
        NetworkManager.Singleton.StartHost();
        NetworkCanvas.SetActive(false);
    }

    void StartClient()
    {
        Debug.Log("Starting Client...");
        NetworkManager.Singleton.StartClient();
        NetworkCanvas.SetActive(false);
    }

    
    
    
    
    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} connected.");
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("You have successfully connected to the server!");
            NetworkCanvas.SetActive(false);
        }
    }

    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} disconnected.");
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("You have been disconnected from the server.");
            NetworkCanvas.SetActive(true);
        }
    }

    
    
    
    
    public void ReturnButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    
    
    
    
    private void SetCursorStatus(bool visible = true)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }
}