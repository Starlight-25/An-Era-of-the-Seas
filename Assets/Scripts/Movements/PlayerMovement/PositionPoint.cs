using System;
using System.Collections.Generic;
using UnityEngine;

public class PositionPoint : MonoBehaviour
{
    private PlayerDataManager PlayerDataManager;

    
    
    
    
    private void Start()
    {
        PlayerDataManager = GameObject.FindFirstObjectByType<PlayerDataManager>();
        TpPositionPoint();
    }

    
    
    

    private void TpPositionPoint()
    {
        List<int> savedPos = PlayerDataManager.PlayerData.Location;
        Vector3 position = new Vector3(savedPos[0], savedPos[1], savedPos[2]);
        transform.GetComponent<CharacterController>().enabled = false;
        transform.position = position;
        transform.GetComponent<CharacterController>().enabled = true;
    }
    
    
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "TownMusicZone") SaveNewPosition(other.transform.position);
    }


    
    
    
    private void SaveNewPosition(Vector3 position)
    {
        PlayerDataManager.PlayerData.Location = new List<int>() { (int)position.x, (int)(position.y + 5), (int)position.z };
        PlayerDataManager.SavePlayerData();
    }
}