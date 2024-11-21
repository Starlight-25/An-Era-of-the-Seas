using System;
using UnityEngine;

public class CreditsScrips : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    
    public void ReturnButton()
    {
        Debug.Log("Return to MainMenu");
        CreditsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape to return to MainMenu");
            ReturnButton();
        }
    }
}
