using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Settings Settings;
    private string SettingsPath;
    [SerializeField] private Slider MusicVolSlider;
    [SerializeField] private Slider SFXVolSlider;
    private AudioManager AudioManager;
    
    
    
    
    
    private void Awake()
    {
        SettingsPath = Path.Combine(Application.persistentDataPath, "settings.json");
        LoadSettings();
        AudioManager = FindFirstObjectByType<AudioManager>();
        MusicVolSlider.value = Settings.Sound.MusicVolume * 100;
        SFXVolSlider.value = Settings.Sound.SFXVolume * 100;
    }

    private void Update()
    {
        SoundVolHandler();
    }

    
    
    
    
    
    public void LoadSettings() =>
        Settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText(SettingsPath));

    public void SaveSettings() =>
        System.IO.File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(Settings, Formatting.Indented));


    
    
    
    private void SoundVolHandler()
    {
        Settings.Sound.MusicVolume = MusicVolSlider.value / 100;
        Settings.Sound.SFXVolume = SFXVolSlider.value / 100;
        SaveSettings();
        AudioManager.UpdateVolume();
    }
}