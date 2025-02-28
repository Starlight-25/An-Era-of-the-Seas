using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float depthbeforesubmerge = 1f;
    public float displacememtAmount = 3f;
    public float floatercount = 1;

    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    private void FixedUpdate(){
        rigidbody.AddForceAtPosition(Physics.gravity / floatercount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveDisplacement(transform.position).y;
        if(transform.position.y < waveHeight){
            float displacememtMultiplier = Mathf.Clamp01((waveHeight-transform.position.y)/ depthbeforesubmerge) * displacememtAmount;
            rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacememtMultiplier, 0f), transform.position,ForceMode.Acceleration);
            rigidbody.AddForce(displacememtMultiplier * -rigidbody.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidbody.AddTorque(displacememtMultiplier * -rigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    } 
}
