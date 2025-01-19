using System;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
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

    public PlayerDataManager playerDataManager;
    public PlayerStatsManager PlayerStatsManager;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI HPText;
    public Slider HPSlider;
    public TextMeshProUGUI DefText;
    public Slider DEFSlider;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SettingsButton();
        else if (Input.GetKeyDown(KeyCode.C)) CharacterButton();
        else if (Input.GetKeyDown(KeyCode.B)) BackpackButton();
        //else if (Input.GetMouseButtonDown(0)) AttackButton();

        LevelText.text = $"Lvl {playerDataManager.PlayerData.Level}";
        HPSlider.maxValue = PlayerStatsManager.PlayerStats.MaxHP;
        HPSlider.value = PlayerStatsManager.PlayerStats.HP;
        HPText.text = $"{HPSlider.value}/{HPSlider.maxValue}";
        DEFSlider.maxValue = PlayerStatsManager.PlayerStats.MaxDEF;
        DEFSlider.value = PlayerStatsManager.PlayerStats.DEF;
        DefText.text = $"{DEFSlider.value}/{DEFSlider.maxValue}";
    }
}
