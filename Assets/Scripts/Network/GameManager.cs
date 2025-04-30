using System.Collections;
using Unity.Mathematics;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private GameObject BoatPrefab;

    
    
    
    
    private void Start()
    {
        StartCoroutine(WaitForHostToSpawn());
    }
    private IEnumerator WaitForHostToSpawn()
    {
        while (NetworkManager.Singleton.ConnectedClients.Count == 0 || NetworkManager.Singleton.ConnectedClients[0].PlayerObject == null)
        {
            yield return null;
        }
        NetworkObject hostObject = NetworkManager.Singleton.ConnectedClients[0].PlayerObject;
        Transform hostTransform = hostObject.transform;
        UIManager uiManager = hostTransform.Find("Player UI").GetComponent<UIManager>();
        
        uiManager.DisplayGameModeMenu();
    }
    
    
    
    
    public void StartTreasureHuntGame()
    {
        transform.GetComponent<TreasureHuntMode>().SpawnChest();
        TeleportAllPlayersServerRpc(new Vector3(500, 5, 500));

    }
    
    
    [ServerRpc(RequireOwnership = false)]
    public void TeleportAllPlayersServerRpc(Vector3 tpPosition)
    {
        // Une fois sur le serveur, demande à tous les clients de se téléporter
        TeleportAllPlayersClientRpc(tpPosition);
    }
    
    [ClientRpc]
    private void TeleportAllPlayersClientRpc(Vector3 tpPosition)
    {
        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            NetworkObject playerObject = client.PlayerObject;
            playerObject.GetComponent<PlayerMovementNetwork>().Teleport(tpPosition);
        }
    }

    
    
    
    
    public void StartBoatRaceGame()
    {
        Debug.Log("Not implemented yet...");
    }
    
    public void SpawnBoats()
    {
        Instantiate(BoatPrefab, new Vector3(20, 5, 20), Quaternion.identity);
    }

}