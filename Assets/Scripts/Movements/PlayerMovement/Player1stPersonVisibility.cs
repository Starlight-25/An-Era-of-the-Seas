using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player1stPersonVisibility : MonoBehaviour
{
    [SerializeField] private MeshRenderer PlayerMeshRenderer;
    [SerializeField] private Material PlayerMaterial;
    [SerializeField] private Material InvisibleMaterial;
    
    
    
    
    
    private void Update()
    {
        Debug.Log(transform.GetComponent<Camera>().enabled);
        if (transform.GetComponent<Camera>().enabled) SetPlayerVisiblility(false);
        else SetPlayerVisiblility(true);
    }
    
    
    
    
    
    private void SetPlayerVisiblility(bool visible)
    {
        if (visible) PlayerMeshRenderer.material = PlayerMaterial;
        else PlayerMeshRenderer.material = InvisibleMaterial;
    }
}
