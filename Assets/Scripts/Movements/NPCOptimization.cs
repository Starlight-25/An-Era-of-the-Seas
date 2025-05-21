using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCOptimization : MonoBehaviour
{
    [SerializeField] private Transform Entities;
    private Dictionary<Vector3, GameObject> EntityposDict;

    
    
    
    
    private void Start()
    {
        if (Entities == null) return; 
        EntityposDict = new Dictionary<Vector3, GameObject>()
        {
            { new Vector3(500, 0, 1500), Entities.GetChild(0).gameObject },
            { new Vector3(1280, 0, 1042), Entities.GetChild(1).gameObject },
            { new Vector3(2432, 0, 1122), Entities.GetChild(2).gameObject },
            { new Vector3(2972, 0, 2185), Entities.GetChild(3).gameObject },
            { new Vector3(2900, 0, 3162), Entities.GetChild(4).gameObject },
            { new Vector3(1819, 0, 3232), Entities.GetChild(5).gameObject },
            { new Vector3(611, 0, 2826), Entities.GetChild(6).gameObject },
            { new Vector3(905, 0, 2205), Entities.GetChild(7).gameObject },
            { new Vector3(1741, 0, 2242), Entities.GetChild(8).gameObject }
        };
    }


    
    
    
    private void Update()
    {
        if (EntityposDict is null) return;
        foreach (Vector3 islandPos in EntityposDict.Keys)
        {
            GameObject islandEntities = EntityposDict[islandPos];
            float distance = Vector3.Distance(transform.position, islandPos);
            if (distance > 500f)
            {
                if (islandEntities.activeInHierarchy) islandEntities.SetActive(false);
                continue;
            }
            if (!islandEntities.activeInHierarchy) islandEntities.SetActive(true);
        }
    }
}