using System.Collections;
using Unity.Netcode;
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
        TeleportAllPlayers(new Vector3(500, 5, 500));

    }
    
    private void TeleportAllPlayers(Vector3 tpPosition)
    {
        foreach (var clientPair in NetworkManager.Singleton.ConnectedClients)
        {
            NetworkObject playerObject = clientPair.Value.PlayerObject;
            if (playerObject != null)
            {
                playerObject.transform.position = tpPosition;
            }
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