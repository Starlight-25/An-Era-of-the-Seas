using TMPro;
using Unity.Netcode;
using UnityEngine;

public class BoatRaceMode : NetworkBehaviour
{

    [SerializeField] private GameObject BuoyPrefab;
    public Vector3 spawnEndPosition = Vector3.zero;
    
    public void SpawnBuoy()
    {
        if (!IsServer) return;
        GameObject startBuoy = Instantiate(BuoyPrefab, spawnEndPosition, Quaternion.identity);
        startBuoy.GetComponent<NetworkObject>().Spawn();

        Debug.Log(spawnEndPosition);
    }
    
}
    
