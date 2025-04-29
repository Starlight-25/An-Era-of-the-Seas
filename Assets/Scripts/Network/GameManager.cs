using System;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private GameObject BoatPrefab;

    private void Start()
    {
        Instantiate(BoatPrefab, new Vector3(20, 5, 20), Quaternion.identity);
    }
}