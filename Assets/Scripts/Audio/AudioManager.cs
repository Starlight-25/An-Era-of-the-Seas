using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    private SettingsManager SettingsManager;
    public AudioSource BackgroundSource;
    private AudioSource SFXSource;
    private AudioSource SFX2Source;
    private List<AudioClip> BackgroundMusics;
    private List<AudioClip> TownMusics;
    private AudioClip ButtonSound;
    private List<Button> trackedButtons = new List<Button>();
    private AudioClip CoinsSound;
    private AudioClip RepairSound;
    private List<AudioClip> SwordsSounds;

    private bool isInTown; 

    
    
    
    
    private void Start()
    {
        SettingsManager = FindFirstObjectByType<SettingsManager>();
        
        BackgroundSource = transform.Find("Background").GetComponent<AudioSource>();
        SFXSource = transform.Find("SFX").GetComponent<AudioSource>();
        SFX2Source = transform.Find("SFX2").GetComponent<AudioSource>();
        UpdateVolume();
        
        BackgroundMusics = new List<AudioClip>();
        BackgroundMusics.AddRange(Resources.LoadAll<AudioClip>("Audio/Music/Outdoors"));
        TownMusics = new List<AudioClip>();
        TownMusics.AddRange(Resources.LoadAll<AudioClip>("Audio/Music/Town"));
        ButtonSound = Resources.Load<AudioClip>("Audio/SFX/Button");
        CoinsSound = Resources.Load<AudioClip>("Audio/SFX/Coins");
        RepairSound = Resources.Load<AudioClip>("Audio/SFX/Repair");
        SwordsSounds = new List<AudioClip>();
        SwordsSounds.Add(Resources.Load<AudioClip>("Audio/SFX/Sword1"));
        SwordsSounds.Add(Resources.Load<AudioClip>("Audio/SFX/Sword2"));

        isInTown = false;
    }

    
    
    
    
    private void Update()
    {
        if (!BackgroundSource.isPlaying)
        {
            if (isInTown) ChangeTownBackgroundMusic();
            else PlayRandomMusic();
        }

        TrackButtons();
    }





    public void UpdateVolume()
    {
        BackgroundSource.volume = SettingsManager.Settings.Sound.MusicVolume;
        SFXSource.volume = SettingsManager.Settings.Sound.SFXVolume;
    }

    
    
    

    public void PlayRandomMusic()
    {
        StartCoroutine(FadeMusic(BackgroundMusics[Random.Range(0, BackgroundMusics.Count)]));
        isInTown = false;
    }
    
    public void ChangeTownBackgroundMusic()
    {
        StartCoroutine(FadeMusic(TownMusics[Random.Range(0, TownMusics.Count)]));
        isInTown = true;
    }

    private IEnumerator FadeMusic(AudioClip newClip)
    {
        if (BackgroundSource.isPlaying)
        {
            for (float v = SettingsManager.Settings.Sound.MusicVolume; v > 0; v -= SettingsManager.Settings.Sound.MusicVolume / 5)
            {
                BackgroundSource.volume = v;
                yield return new WaitForSeconds(0.1f);
            }
        }
        BackgroundSource.clip = newClip;
        BackgroundSource.volume = SettingsManager.Settings.Sound.MusicVolume;
        BackgroundSource.Play();
    }
    


    
    
    

    public void TriggerButtonSound()
    {
        SFXSource.clip = ButtonSound;
        SFXSource.Play();
    }

    private void TrackButtons()
    {
        Button[] buttons = FindObjectsByType<Button>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (Button button in buttons)
        {
            if (!trackedButtons.Contains(button))
            {
                button.onClick.AddListener(TriggerButtonSound);
                trackedButtons.Add(button);
            }
        }
    }
    
    public void TriggerCoinsSounds()
    {
        SFX2Source.clip = CoinsSound;
        SFX2Source.Play();
    }
    
    public void TriggerRepairSounds()
    {
        SFX2Source.clip = RepairSound;
        SFX2Source.Play();
    }
    
    public void TriggerSwordSounds()
    {
        SFXSource.clip = SwordsSounds[Random.Range(0, 2)];
        SFXSource.Play();
    }
}