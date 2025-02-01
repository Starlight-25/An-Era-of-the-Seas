using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    [System.Serializable]
    public class GerstnerWave
    {
        public float amplitude = 1f;      
        public float wavelength = 2f;  
        public float speed = 1f;        
        public float directionAngle = 0f; 
    }

    public List<GerstnerWave> waves = new List<GerstnerWave>();
    private List<Vector2> waveDirections = new List<Vector2>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("WaveManager instance already exists!");
        }

        // Precompute wave directions
        foreach (var wave in waves)
        {
            Vector2 direction = new Vector2(
                Mathf.Cos(wave.directionAngle * Mathf.Deg2Rad),
                Mathf.Sin(wave.directionAngle * Mathf.Deg2Rad)
            ).normalized;
            waveDirections.Add(direction);
        }
    }

    public Vector3 GetWaveDisplacement(Vector3 position)
    {
        Vector3 displacement = Vector3.zero;

        for (int i = 0; i < waves.Count; i++)
        {
            var wave = waves[i];
            Vector2 waveDirection = waveDirections[i];

            float phase = Vector2.Dot(new Vector2(position.x, position.z), waveDirection) / wave.wavelength + Time.time * wave.speed;
            float waveHeight = wave.amplitude * Mathf.Sin(phase);

            float horizontalDisplacement = wave.amplitude * Mathf.Cos(phase);

            displacement.x += horizontalDisplacement * waveDirection.x;
            displacement.z += horizontalDisplacement * waveDirection.y;
            displacement.y += waveHeight;
        }

        return displacement;
    }
}
