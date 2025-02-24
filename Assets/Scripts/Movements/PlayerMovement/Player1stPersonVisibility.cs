using UnityEngine;

public class Player1stPersonVisibility : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer PlayerMeshRenderer;
    [SerializeField] private UnityEngine.Material PlayerMaterial;
    [SerializeField] private UnityEngine.Material InvisibleMaterial;
    
    
    
    
    
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
