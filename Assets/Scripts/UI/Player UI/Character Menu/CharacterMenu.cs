using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public GameObject PlayerUICanvas;
    public GameObject CharacterCanvas;

    public void ReturnInGameButton()
    {
        CharacterCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnInGameButton();
    }
    
    
    
    
    
    
    
    
    
    
    public GameObject LevelUPElements;
    public GameObject StigmataElements;
    public GameObject BoatElements;
    public GameObject CrewMembersElements;

    
    
    
    
    public PlayerStatsManager PlayerStatsManager;
    public JsonData JsonData;
    
    public TextMeshProUGUI PlayerStats;
    public TextMeshProUGUI PlayerLevel;
    public Slider PlayerLevelSlider;
    public TextMeshProUGUI BoatStats1;
    public TextMeshProUGUI BoatStats2;
    public TextMeshProUGUI BoatLevel;
    public Slider BoatLevelSlider;
    public TextMeshProUGUI Stigma1Stats;
    public TextMeshProUGUI Stigma2Stats;

    
    
    
    
    public void PlayerButton()
    {
        StigmataElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        LevelUPElements.SetActive(true);
        InitPlayerStats();
    }

    private void InitPlayerStats()
    {
        string text = "";
        text += $"HP: {PlayerStatsManager.PlayerStats.MaxHP}\n";
        text += $"DEF: {PlayerStatsManager.PlayerStats.MaxDEF}\n";
        text += $"ATK: {PlayerStatsManager.PlayerStats.ATK}\n";
        text += $"Crit Rate: {PlayerStatsManager.PlayerStats.CritRate}\n";
        text += $"Crit DMG: {PlayerStatsManager.PlayerStats.CritDMG}\n";
        PlayerStats.text = text;

        PlayerLevelSlider.value = PlayerStatsManager.PlayerStats.Level;
        PlayerLevel.text = $"Level {PlayerLevelSlider.value}/100";
    }

    
    
    
    
    
    public void StigmataButton()
    {
        LevelUPElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        StigmataElements.SetActive(true);
    }
    
    
    
    
    
    
    public void BoatButton()
    {
        LevelUPElements.SetActive(false);
        StigmataElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        BoatElements.SetActive(true);
        InitBoatStats();
    }

    private void InitBoatStats()
    {
        string text1 = "";
        text1 += $"{PlayerStatsManager.BoatStats.Name}\n";
        text1 += $"HP: {PlayerStatsManager.BoatStats.MaxHP}\n";
        text1 += $"DEF: {PlayerStatsManager.BoatStats.MaxDEF}\n";
        text1 += $"Speed: {PlayerStatsManager.BoatStats.Speed}\n";
        BoatStats1.text = text1;
        
        string text2 = "\n";
        text2 += $"ATK: {PlayerStatsManager.BoatStats.ATK}\n";
        text2 += $"Crit Rate: {PlayerStatsManager.BoatStats.CritRate}\n";
        text2 += $"Crit DMG: {PlayerStatsManager.BoatStats.CritDMG}\n";
        BoatStats2.text = text2;

        BoatLevelSlider.maxValue = JsonData.GetBoat(PlayerStatsManager.BoatStats.Name).MaxLevel;
        BoatLevelSlider.value = PlayerStatsManager.BoatStats.Level;
        BoatLevel.text = $"Level {BoatLevelSlider.value}/{BoatLevelSlider.maxValue}";
    }
    
    
    
    
    
    public void CrewMembersButton()
    {
        LevelUPElements.SetActive(false);
        StigmataElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(true);
    }
}
