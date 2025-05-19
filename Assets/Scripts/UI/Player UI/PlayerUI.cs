using System;
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
    [SerializeField] private GameObject ShopCanvas;

    public void SettingsButtonClicked()
    {
        Time.timeScale = 0f;
        SetCursorState();
        PlayerUICanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void CharacterButtonClicked()
    {
        Time.timeScale = 0f;
        SetCursorState();
        CharacterCanvas.transform.GetComponent<CharacterMenu>().SetPreviousCanvas(PlayerUICanvas);
        PlayerUICanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
    }

    public void BackpackButtonClicked()
    {
        Time.timeScale = 0f;
        SetCursorState();
        BackpackCanvas.transform.GetComponent<BackpackMenuManager>().SetPreviousCanvas(PlayerUICanvas);
        PlayerUICanvas.SetActive(false);
        BackpackCanvas.SetActive(true);
    }

    public void MapButtonClicked()
    {
        Time.timeScale = 0f;
        SetCursorState();
        MapCanvas.transform.GetComponent<MapMenu>().SetPreviousCanvas(PlayerUICanvas);
        PlayerUICanvas.SetActive(false);
        MapCanvas.SetActive(true);
    }

    public void BoatButtonClicked()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<BoatInitHandler>().HandlePlaceBoat();
    }

    public void ShopCanvasShow()
    {
        Time.timeScale = 0f;
        SetCursorState();
        ShopCanvas.SetActive(true);
        PlayerUICanvas.SetActive(false);
    }

    private void SetCursorState(bool locked = false)
    {
        Cursor.visible = !locked;
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    [SerializeField] private PlayerDataManager playerDataManager;
    [SerializeField] private PlayerStatsManager PlayerStatsManager;
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private Slider HPSlider;
    [SerializeField] private TextMeshProUGUI DefText;
    [SerializeField] private Slider DEFSlider;


    private void OnEnable()
    {
        Time.timeScale = 1f;
        SetCursorState(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SettingsButtonClicked();
        else if (Input.GetKeyDown(KeyCode.C)) CharacterButtonClicked();
        else if (Input.GetKeyDown(KeyCode.B)) BackpackButtonClicked();
        else if (Input.GetKeyDown(KeyCode.M)) MapButtonClicked();
        else if (Input.GetKeyDown(KeyCode.H)) BoatButtonClicked();

        HpDefBarUpdate();
    }



    private void HpDefBarUpdate()
    {
        LevelText.text = $"Lvl {playerDataManager.PlayerData.Level}";
        if (FindFirstObjectByType<BoatInitHandler>().BoatState.inBoat)
        {
            HPSlider.maxValue = PlayerStatsManager.BoatStats.MaxHP;
            HPSlider.value = PlayerStatsManager.BoatStats.HP;
            HPText.text = $"{HPSlider.value}/{HPSlider.maxValue}";
            DEFSlider.maxValue = PlayerStatsManager.BoatStats.MaxDEF;
            DEFSlider.value = PlayerStatsManager.BoatStats.DEF;
            DefText.text = $"{DEFSlider.value}/{DEFSlider.maxValue}";
        }
        else
        {
            HPSlider.maxValue = PlayerStatsManager.PlayerStats.MaxHP;
            HPSlider.value = PlayerStatsManager.PlayerStats.HP;
            HPText.text = $"{HPSlider.value}/{HPSlider.maxValue}";
            DEFSlider.maxValue = PlayerStatsManager.PlayerStats.MaxDEF;
            DEFSlider.value = PlayerStatsManager.PlayerStats.DEF;
            DefText.text = $"{DEFSlider.value}/{DEFSlider.maxValue}";
        }
    }
}
