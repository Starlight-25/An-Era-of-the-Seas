using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RainManager : MonoBehaviour
{
    private float rainInterval = 1200f;
    private float rainDuration = 180f;
    private ParticleSystem rainParticle;
    
    
    
    
    
    private void Start()
    {
        rainParticle = transform.GetComponent<ParticleSystem>();
        rainParticle.Stop();
        StartCoroutine(RainRoutine(Random.Range(0f, rainInterval)));
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }


    IEnumerator RainRoutine(float initDelay)
    {
        yield return new WaitForSeconds(initDelay);

        while (true)
        {
            rainParticle.Play();
            yield return new WaitForSeconds(rainDuration);

            rainParticle.Stop();
            yield return new WaitForSeconds(rainInterval);
        }
    }
}