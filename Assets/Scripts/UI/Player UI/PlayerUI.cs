using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUICanvas;
    [SerializeField] private GameObject SettingsCanvas;
    [SerializeField] private GameObject BackpackCanvas;
    [SerializeField] private GameObject CharacterCanvas;
    [SerializeField] private GameObject MapCanvas;

    public void SettingsButtonClicked()
    {
        PlayerUICanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void CharacterButtonClicked()
    {
        CharacterCanvas.transform.GetComponent<CharacterMenu>().SetPreviousCanvas(PlayerUICanvas);
        PlayerUICanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
    }

    public void BackpackButtonClicked()
    {
        BackpackCanvas.transform.GetComponent<BackpackMenuManager>().SetPreviousCanvas(PlayerUICanvas);
        PlayerUICanvas.SetActive(false);
        BackpackCanvas.SetActive(true);
    }

    public void MapButtonClicked()
    {
        MapCanvas.transform.GetComponent<MapMenu>().SetPreviousCanvas(PlayerUICanvas);
        PlayerUICanvas.SetActive(false);
        MapCanvas.SetActive(true);
    }

    public void AttackButtonClicked()
    {
        Debug.Log("Attack");
    }

    [SerializeField] private PlayerDataManager playerDataManager;
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private Slider HPSlider;
    [SerializeField] private TextMeshProUGUI DefText;
    [SerializeField] private Slider DEFSlider;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SettingsButtonClicked();
        else if (Input.GetKeyDown(KeyCode.C)) CharacterButtonClicked();
        else if (Input.GetKeyDown(KeyCode.B)) BackpackButtonClicked();
        else if (Input.GetKeyDown(KeyCode.M)) MapButtonClicked();
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
