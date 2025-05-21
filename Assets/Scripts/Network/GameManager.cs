using System.Collections;
using Unity.Mathematics;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;





public enum GameMode
{
    TreasureHunt,
    BoatRace
}





public class GameManager : NetworkBehaviour
{
    [SerializeField] private GameObject BoatPrefab;
    [SerializeField] private WaterManagerNetwork WaterManager;
    public static GameMode Mode; // False == Treasure Hunt && True == Boat Race
    
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
        Mode = GameMode.TreasureHunt;
        transform.GetComponent<TreasureHuntMode>().SpawnChest();
        TeleportAllPlayersServerRpc(new Vector3(500, 5, 500));
        WaterManager.Initialize();
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
        Mode = GameMode.BoatRace;
        transform.GetComponent<BoatRaceMode>().SpawnBuoy();
        TeleportAllPlayersServerRpc(new Vector3(200, 10, 445));
        SpawnBoats();
        WaterManager.Initialize();
    }
    
    public void SpawnBoats()
    {
        GameObject boat1 = Instantiate(BoatPrefab, new Vector3(175, 5, 445), Quaternion.identity);
        GameObject boat2 = Instantiate(BoatPrefab, new Vector3(167, 5, 445), Quaternion.identity);
        boat1.GetComponent<NetworkObject>().Spawn();
        boat2.GetComponent<NetworkObject>().Spawn();
    }

}