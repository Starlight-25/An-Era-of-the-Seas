using System;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    [SerializeField] public int QuestLevel;
    [SerializeField] private Transform QuestNPCCanvas;
    private Transform Player;


    
    
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    
    
    
    private void Update()
    {
        transform.LookAt(Player);
    }
}