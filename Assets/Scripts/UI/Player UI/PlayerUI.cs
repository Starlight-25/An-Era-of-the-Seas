using System;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

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

    public PlayerDataManager playerDataManager;
    public PlayerStatsManager PlayerStatsManager;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI DefText;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SettingsButton();
        else if (Input.GetKeyDown(KeyCode.C)) CharacterButton();
        else if (Input.GetKeyDown(KeyCode.B)) BackpackButton();
        //else if (Input.GetMouseButtonDown(0)) AttackButton();

        LevelText.text = $"Lvl {playerDataManager.PlayerData.Level}";
        HPText.text = $"{PlayerStatsManager.PlayerStats.HP}/{PlayerStatsManager.PlayerStats.MaxHP}";
        DefText.text = $"{PlayerStatsManager.PlayerStats.DEF}/{PlayerStatsManager.PlayerStats.MaxDEF}";
    }
}
