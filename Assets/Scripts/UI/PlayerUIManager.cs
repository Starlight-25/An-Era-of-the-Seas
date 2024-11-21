using System;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public GameObject PlayerUICanvas;
    public GameObject SettingsCanvas;
    public GameObject BackpackCanvas;
    public GameObject CharacterCanvas;

    public void SettingsButton()
    {
        Debug.Log("Settings Menu");
        PlayerUICanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void CharacterButton()
    {
        Debug.Log("Character Menu");
        PlayerUICanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
    }

    public void BackpackButton()
    {
        Debug.Log("Backpack Menu");
        PlayerUICanvas.SetActive(false);
        BackpackCanvas.SetActive(true);
    }

    public void AttackButton()
    {
        Debug.Log("Attack");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SettingsButton();
        else if (Input.GetKeyDown(KeyCode.C)) CharacterButton();
        else if (Input.GetKeyDown(KeyCode.B)) BackpackButton();
        else if (Input.GetMouseButtonDown(0)) AttackButton();
    }
}
