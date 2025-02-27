using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    private AudioSource BackgroundSource;
    private AudioSource SFXSource;
    private List<AudioClip> BackgroundMusics;
    private AudioClip ButtonSound;

    
    
    
    
    private void Start()
    {
        BackgroundSource = transform.Find("Background").GetComponent<AudioSource>();
        BackgroundSource.volume = 0.5f;
        SFXSource = transform.Find("SFX").GetComponent<AudioSource>();
        
        BackgroundMusics = new List<AudioClip>();
        BackgroundMusics.AddRange(Resources.LoadAll<AudioClip>("Audio/Music/Outdoors"));
    }

    
    
    
    
    private void Update()
    {
        if (!BackgroundSource.isPlaying) PlayRandomMusic();
    }

    
    
    
    
    private void PlayRandomMusic()
    {
        AudioClip newclip = BackgroundMusics[Random.Range(0, BackgroundMusics.Count)];
        BackgroundSource.clip = newclip;
        BackgroundSource.Play();
    }


    
    

    private void TriggerButtonSound()
    {
        SFXSource.clip = ButtonSound;
        SFXSource.Play();
    }
}