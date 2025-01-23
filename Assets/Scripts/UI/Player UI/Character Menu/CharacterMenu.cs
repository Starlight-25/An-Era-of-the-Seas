using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUICanvas;
    [SerializeField] private GameObject CharacterCanvas;
    [SerializeField] private GameObject UpgradeCanvas;
    [SerializeField] private UpgradeUI UpgradeUIScript;

    public void ReturnButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        PlayerUICanvas.SetActive(true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) ReturnButtonClicked();
    }
    
    
    
    
    
    
    
    
    
    
    [SerializeField] private GameObject LevelUPElements;
    [SerializeField] private GameObject StigmataElements;
    [SerializeField] private GameObject BoatElements;
    [SerializeField] private GameObject CrewMembersElements;

    
    
    
    
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    [SerializeField] private JsonData JsonData;
    
    [SerializeField] private TextMeshProUGUI PlayerStats;
    [SerializeField] private TextMeshProUGUI PlayerLevel;
    [SerializeField] private Slider PlayerLevelSlider;
    [SerializeField] private TextMeshProUGUI BoatStats1;
    [SerializeField] private TextMeshProUGUI BoatStats2;
    [SerializeField] private TextMeshProUGUI BoatLevel;
    [SerializeField] private Slider BoatLevelSlider;
    [SerializeField] private TextMeshProUGUI Stigma1Stats;
    [SerializeField] private TextMeshProUGUI Stigma2Stats;

    
    
    
    
    public void PlayerButtonClicked()
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

    
    
    
    
    
    public void StigmataButtonClicked()
    {
        LevelUPElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(false);
        StigmataElements.SetActive(true);
    }
    
    
    
    
    
    
    public void BoatButtonClicked()
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
    
    
    
    
    
    public void CrewMembersButtonClicked()
    {
        LevelUPElements.SetActive(false);
        StigmataElements.SetActive(false);
        BoatElements.SetActive(false);
        CrewMembersElements.SetActive(true);
    }




    public void UpgradeButtonClicked()
    {
        CharacterCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
        UpgradeUIScript.Init(CharacterCanvas);
    }
}
