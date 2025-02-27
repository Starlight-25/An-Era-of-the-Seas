using UnityEngine;

public class BackpackMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject BackpackCanvas;
    private GameObject PreviousCanvas;

    
    public void SetPreviousCanvas(GameObject previousCanvas) => PreviousCanvas = previousCanvas;
    
    public void ReturnInGameButton()
    {
        BackpackCanvas.SetActive(false);
        PreviousCanvas.SetActive(true);
        PreviousCanvas = null;
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnInGameButton();
    }
}
