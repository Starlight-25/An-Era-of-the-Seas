using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player1stPersonVisibility : MonoBehaviour
{
    private SkinnedMeshRenderer PlayerMeshRenderer;
    [SerializeField] private Material PlayerMaterial;
    [SerializeField] private Material InvisibleMaterial;


    private void Start() =>
        PlayerMeshRenderer = transform.Find("Pirate").Find("Pirate").GetComponent<SkinnedMeshRenderer>();


    private void Update()
    {
        if (transform.Find("Camera").GetComponent<Camera>().enabled || BoatState.inHelm) SetPlayerVisiblility(false);
        else SetPlayerVisiblility(true);
    }
    
    
    
    
    
    private void SetPlayerVisiblility(bool visible)
    {
        if (visible) PlayerMeshRenderer.material = PlayerMaterial;
        else PlayerMeshRenderer.material = InvisibleMaterial;
    }
}
