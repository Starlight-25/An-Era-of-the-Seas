using System;
using UnityEngine;

public class BoatInitHandler : MonoBehaviour
{
    public Transform Boat;
    [SerializeField] public BoatState BoatState;

    private void Start()
    {
        Boat = GetComponentInChildren<BoatMovement>(true).transform;
        //BoatState = Boat.GetComponent<BoatState>();
        
        BoatStats boatStats = GameObject.FindFirstObjectByType<PlayerStatsManager>().BoatStats;
        SwitchBoat(boatStats.Name);
    }


    public void HandlePlaceBoat()
    {
        if (BoatState.isPlaced && !BoatState.inBoat && !BoatState.inHelm)
        {
            Boat.SetParent(transform);
            Boat.position = Vector3.zero;
            Boat.gameObject.SetActive(false);
        }
        else
        {
            Boat.SetParent(null);
            Boat.position = transform.position + transform.forward * 10f + transform.up * 1f;
            Boat.rotation = transform.rotation;
            Boat.gameObject.SetActive(true);
        }
        BoatState.isPlaced = !BoatState.isPlaced;
    }



    public void SwitchBoat(string name)
    {
        GameObject newBoat = Resources.Load<GameObject>($"3D/Boats/{name}");
        if (BoatState.inBoat) transform.GetComponent<InteractorHandler>().ExitBoat(Boat);
        Destroy(Boat.gameObject);
        GameObject newInstance = Instantiate(newBoat);
        Boat = newInstance.transform;
        Boat.SetParent(transform);
        Boat.position = Vector3.zero;
        BoatState = Boat.GetComponent<BoatState>();
        transform.GetComponent<InteractorHandler>().SwitchBoat(BoatState);
        Boat.gameObject.SetActive(false);
    }
}