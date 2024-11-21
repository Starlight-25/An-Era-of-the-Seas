using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public void SoloButton()
    {
        Debug.Log("Solo Mode");
        //SceneManager.LoadScene("Solo mode");
    }

    public void MultiplayerButton()
    {
        Debug.Log("Multiplayer mode");
        //SceneManager.LoadScene("Solo mode");
    }
    
    public void CreditsButton()
    {
        Debug.Log("Credits scene");
        MainMenuCanvas.SetActive(false); 
        CreditsCanvas.SetActive(true);
    }
    
    public void QuitButton()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}