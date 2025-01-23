using System;
using UnityEngine;
using UnityEngine.Serialization;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUICanvas;
    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private GameObject CharacterCanvas;
    [SerializeField] private GameObject BackpackCanvas;

    public void ReturnButtonClicked()
    {
        SettingsCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }

    public void CharacterButtonClicked()
    {
        SettingsCanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
    }
    
    public void BackpackButtonClicked()
    {
        SettingsCanvas.SetActive(false);
        BackpackCanvas.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }
}
