using System;
using UnityEngine;

public class CreditsScrips : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    
    public void ReturnButtonClicked()
    {
        CreditsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnButtonClicked();
        }
    }
}
