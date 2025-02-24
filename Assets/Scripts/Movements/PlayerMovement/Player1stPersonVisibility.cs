using UnityEngine;


public class Player1stPersonVisibility : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer PlayerMeshRenderer;
    [SerializeField] private Material PlayerMaterial;
    [SerializeField] private Material InvisibleMaterial;
    
    
    
    
    
    private void Update()
    {
        if (transform.GetComponent<Camera>().enabled) SetPlayerVisiblility(false);
        else SetPlayerVisiblility(true);
    }
    
    
    
    
    
    private void SetPlayerVisiblility(bool visible)
    {
        if (visible) PlayerMeshRenderer.material = PlayerMaterial;
        else PlayerMeshRenderer.material = InvisibleMaterial;
    }
}
