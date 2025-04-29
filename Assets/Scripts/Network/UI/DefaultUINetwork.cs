using System;
using UnityEngine;

public class DefaultUINetwork : MonoBehaviour
{
    [SerializeField] private GameObject DefaultUI;
    [SerializeField] private GameObject SettingsMenu;


    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        SetCursorStatus(Input.GetKey(KeyCode.LeftAlt));
        if (Input.GetKeyDown(KeyCode.Escape)) SettingsButtonClicked();
    }

    
    
    
    
    public void SettingsButtonClicked()
    {
        SettingsMenu.SetActive(true);
        DefaultUI.SetActive(false);
        SetCursorStatus();
    }





    private void SetCursorStatus(bool visible = true)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }
}