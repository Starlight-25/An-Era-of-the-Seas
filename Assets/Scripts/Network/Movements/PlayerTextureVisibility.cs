using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerTextureVisibility : NetworkBehaviour
{
    [SerializeField] private UnityEngine.Material PlayerMaterial;
    [SerializeField] private UnityEngine.Material InvisibleMaterial;

    private Camera Camera;
    private SkinnedMeshRenderer playerMeshRenderer;

    
    
    
    
    private void Start()
    {
        Camera = transform.Find("Camera").GetComponent<Camera>();
        playerMeshRenderer = transform.Find("Pirate").Find("Pirate").GetComponent<SkinnedMeshRenderer>();
    }


    
    
    
    private void Update()
    {
        if (IsOwner)
        {
            if (Camera.enabled) SetPlayerVisible(false);
            else SetPlayerVisible(true);
        }
        else
        {
            SetPlayerVisible(true);
        }
    }

    
    
    
    
    private void SetPlayerVisible(bool visible) =>
        playerMeshRenderer.material = visible ? PlayerMaterial : InvisibleMaterial;
}
