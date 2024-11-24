using System;
using UnityEngine;
using UnityEngine.Serialization;

public class SettingsMenuManager : MonoBehaviour
{
    public GameObject PlayerUICanvas;
    public GameObject SettingsCanvas;
    public GameObject CharacterCanvas;
    public GameObject BackpackCanvas;

    public void ReturnInGameButton()
    {
        SettingsCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }

    public void CharacterButton()
    {
        SettingsCanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
    }
    
    public void BackpackButton()
    {
        SettingsCanvas.SetActive(false);
        BackpackCanvas.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnInGameButton();
    }
}
