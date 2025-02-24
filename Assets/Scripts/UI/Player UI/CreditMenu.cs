using System;
using UnityEngine;
using UnityEngine.Serialization;


public class CreditMenu : MonoBehaviour
{
    [SerializeField] private GameObject CreditCanvas;
    [SerializeField] private GameObject SettingsCanvas;

    public void ReturnButtonClicked()
    {
        CreditCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnButtonClicked();
        }
    }
}