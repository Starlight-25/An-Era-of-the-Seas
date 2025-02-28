using System;
using UnityEngine;

public class BoatInitHandler : MonoBehaviour
{
    public Transform Boat;
    public BoatState BoatState;
    private string BoatName;

    private void Start()
    {
        Boat = GetComponentInChildren<BoatMovement>(true).transform;
        BoatState = Boat.GetComponent<BoatState>();
        BoatName = "Boat" + GameObject.FindFirstObjectByType<PlayerDataManager>().PlayerData.Pseudo;
        Boat.name = BoatName;
    }


    public void HandlePlaceBoat()
    {
        if (BoatState.isPlaced)
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
        BoatState.isPlaced = !BoatState.isPlaced;
    }



    public void SwitchBoat(string name)
    {
        GameObject newBoat = Resources.Load<GameObject>($"3D/Boats/{name}");
        Destroy(Boat.gameObject);
        Boat = newBoat.transform;
        Instantiate(Boat.gameObject);
        Boat.SetParent(transform);
        Boat.position = Vector3.zero;
        Boat.name = BoatName;
        BoatState.isPlaced = false;
        Boat.gameObject.SetActive(false);
    }
}