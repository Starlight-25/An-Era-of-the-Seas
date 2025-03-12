using System;
using UnityEngine;

public class TownMusicZone : MonoBehaviour
{
    private AudioManager AudioManager;

    
    
    
    
    private void Start() => AudioManager = GameObject.Find("Audio").GetComponent<AudioManager>();

    
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) AudioManager.ChangeTownBackgroundMusic();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !AudioManager.BackgroundSource.isPlaying) AudioManager.ChangeTownBackgroundMusic();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) AudioManager.PlayRandomMusic();
    }
}