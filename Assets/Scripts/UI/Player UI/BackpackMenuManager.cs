using UnityEngine;

public class BackpackMenuManager : MonoBehaviour
{
    public GameObject PlayerUICanvas;
    public GameObject BackpackCanvas;

    public void ReturnInGameButton()
    {
        BackpackCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnInGameButton();
    }
}
