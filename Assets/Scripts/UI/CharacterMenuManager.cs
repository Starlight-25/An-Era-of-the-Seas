using UnityEngine;

public class CharacterMenuManager : MonoBehaviour
{
    public GameObject PlayerUICanvas;
    public GameObject CharacterCanvas;

    public void ReturnInGameButton()
    {
        Debug.Log("Player UI");
        CharacterCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnInGameButton();
    }
}
