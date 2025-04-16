using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RainManager : MonoBehaviour
{
    private float rainInterval = 1200f;
    private float rainDuration = 180f;

    private void Start()
    {
        StartCoroutine(RainRoutine(Random.Range(0f, rainInterval)));
        transform.gameObject.SetActive(false);
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
            transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(rainDuration);

            transform.gameObject.SetActive(false);
            yield return new WaitForSeconds(rainInterval);
        }
    }
}