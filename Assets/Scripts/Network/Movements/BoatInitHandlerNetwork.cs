using System;
using Unity.Netcode;
using UnityEngine;

public class BoatInitHandlerNetwork : NetworkBehaviour
{
    public Transform Boat;
    public BoatStateNetwork BoatStateNetwork;

    private void Start()
    {
        Boat = GetComponentInChildren<BoatMovementNetwork>(true).transform;
        BoatStateNetwork = Boat.GetComponent<BoatStateNetwork>();
        
        //BoatStats boatStats = GameObject.FindFirstObjectByType<PlayerStatsManager>().BoatStats;
        //SwitchBoat(boatStats.Name);
    }


    public void HandlePlaceBoat()
    {
        if (!IsOwner) return;
        
        if (BoatStateNetwork.isPlaced)
        {
            Boat.SetParent(transform);
            Boat.position = Vector3.zero;
            Boat.gameObject.SetActive(false);
        }
        else
        {
            Boat.SetParent(null);
            Boat.position = transform.position + transform.forward * 10f + transform.up * 1f;
            Boat.gameObject.SetActive(true);
        }
        BoatStateNetwork.isPlaced = !BoatStateNetwork.isPlaced;
    }



    public void SwitchBoat(string name)
    {
        GameObject newBoat = Resources.Load<GameObject>($"3D/Boats/{name}");
        if (BoatStateNetwork.inBoat) transform.GetComponent<InteractorHandler>().ExitBoat(Boat);
        Destroy(Boat.gameObject);
        GameObject newInstance = Instantiate(newBoat);
        Boat = newInstance.transform;
        Boat.SetParent(transform);
        Boat.position = Vector3.zero;
        BoatStateNetwork.isPlaced = false;
        Boat.gameObject.SetActive(false);
    }
}