using UnityEngine;
using Unity.Netcode;

public class PlayerCameraController : NetworkBehaviour
{
    void Start() 
    {
        if (!IsOwner) transform.Find("Camera").gameObject.SetActive(false);
    }
}