using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public class BoatRaceMode : NetworkBehaviour
{

    [SerializeField] private GameObject FlagPrefab;
    public Vector3 spawnEndPosition = Vector3.zero;
    
    public void SpawnBuoy()
    {
        if (!IsServer) return;
        GameObject flag = Instantiate(FlagPrefab, spawnEndPosition, Quaternion.identity);
        flag.GetComponent<NetworkObject>().Spawn();

        Debug.Log(spawnEndPosition);
    }
    
}
    
