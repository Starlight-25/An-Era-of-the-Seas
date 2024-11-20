using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
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
        //SceneManager.LoadScene("Solo mode");
    }
    
    public void QuitButton()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}