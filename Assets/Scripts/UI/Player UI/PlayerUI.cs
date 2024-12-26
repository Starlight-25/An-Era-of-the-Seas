using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public GameObject PlayerUICanvas;
    public GameObject SettingsCanvas;
    public GameObject BackpackCanvas;
    public GameObject CharacterCanvas;

    public void SettingsButton()
    {
        PlayerUICanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void CharacterButton()
    {
        PlayerUICanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
    }

    public void BackpackButton()
    {
        PlayerUICanvas.SetActive(false);
        BackpackCanvas.SetActive(true);
    }

    public void AttackButton()
    {
        Debug.Log("Attack");
    }

    public Text LevelText;
    
    public void LoadPlayerData()
    {
        string savePath = Path.Combine(Application.persistentDataPath, "playerData.json");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SettingsButton();
        else if (Input.GetKeyDown(KeyCode.C)) CharacterButton();
        else if (Input.GetKeyDown(KeyCode.B)) BackpackButton();
        //else if (Input.GetMouseButtonDown(0)) AttackButton();
    }
}
