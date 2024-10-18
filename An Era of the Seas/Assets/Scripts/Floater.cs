using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float depthbeforesubmerge = 1f;
    public float displacememtAmount = 3f;
    private void FixedUpdate(){

        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if(transform.position.y < waveHeight){
            float displacememtMultiplier = Mathf.Clamp01((waveHeight-transform.position.y)/ depthbeforesubmerge) * displacememtAmount;
            rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacememtAmount, 0f), transform.position,ForceMode.Acceleration);
        }

        
    } 
    
}
