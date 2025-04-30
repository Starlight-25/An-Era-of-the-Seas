using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerUIManager : NetworkBehaviour
{
    [SerializeField] private GameObject PlayerNetworkCanvas;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) PlayerNetworkCanvas.SetActive(false);
    }
}