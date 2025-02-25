using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovementOnWaterNetwork : NetworkBehaviour
{
    private LayerMask WaterLayer;


    
    
    
    private void Start()
    {
        WaterLayer = LayerMask.GetMask("Water");
    }

    
    
    

    private void Update()
    {
        bool isOnWater = DetectWater();
        if (WaveManager.instance != null && isOnWater)
        {
            Vector3 waveDisplacement = WaveManager.instance.GetWaveDisplacement(transform.position);

            float currentHeight = transform.position.y;
            float verticalMove = Mathf.Lerp(currentHeight, waveDisplacement.y, Time.deltaTime * 5f) -
                                 currentHeight - 1f;
            transform.GetComponent<CharacterController>().Move(new Vector3(0, verticalMove, 0));

            transform.GetComponent<PlayerMovement>().speed = 5f;
        }
        else
        {
            transform.GetComponent<PlayerMovement>().speed = 12f;
        }
    }

    private bool DetectWater()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, 1.6f, WaterLayer);
    }
}
