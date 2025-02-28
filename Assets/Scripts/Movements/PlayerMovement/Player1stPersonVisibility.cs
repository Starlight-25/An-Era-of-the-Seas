using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player1stPersonVisibility : MonoBehaviour
{
    private SkinnedMeshRenderer PlayerMeshRenderer;
    [SerializeField] private UnityEngine.Material PlayerMaterial;
    [SerializeField] private UnityEngine.Material InvisibleMaterial;
    private BoatState BoatState;


    private void Start()
    {
        PlayerMeshRenderer = transform.Find("Pirate").Find("Pirate").GetComponent<SkinnedMeshRenderer>();
        BoatState = transform.GetComponent<BoatInitHandler>().BoatState;
    }


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
