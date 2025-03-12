using Unity.Netcode;
using UnityEngine;

public class BoatStateNetwork : NetworkBehaviour
{
    public bool isAnchored = true;
    public bool inHelm = false;
    public bool inBoat = false;
    public bool isPlaced = false;
}