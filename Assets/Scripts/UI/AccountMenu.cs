using System;
using UnityEngine;

public class AccountMenu : MonoBehaviour
{
    public GameObject AccountCanvas;
    public GameObject MainMenuCanvas;
    public GameObject LoginButton;
    public GameObject RegisterButton;
    public GameObject LoginElements;
    public GameObject RegisterElements;
    private string State;

    private void OnEnable()
    {
        State = "Choice";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnButtonClicked();
        }
    }

    public void LoginButtonClicked()
    {
        State = "Login";
        LoginButton.SetActive(false);
        RegisterButton.SetActive(false);
        LoginElements.SetActive(true);
    }

    public void RegisterButtonClicked()
    {
        State = "Register";
        LoginButton.SetActive(false);
        RegisterButton.SetActive(false);
        RegisterElements.SetActive(true);
    }


    public void ReturnButtonClicked()
    {
        switch (State)
        {
            case "Choice":
                AccountCanvas.SetActive(false);
                MainMenuCanvas.SetActive(true);
                break;
            case "Login":
                LoginElements.SetActive(false);
                LoginButton.SetActive(true);
                RegisterButton.SetActive(true);
                break;
            case "Register":
                RegisterElements.SetActive(false);
                LoginButton.SetActive(true);
                RegisterButton.SetActive(true);
                break;
        }
    }
}
