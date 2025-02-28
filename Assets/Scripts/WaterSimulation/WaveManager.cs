using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    [System.Serializable]
    public class ImpactPoint
    {
        public Vector3 position;
        public float maxAmplitude;
        public float influenceRadius;
        public float wavelength;
        public float speed;
        public float directionAngle; 
    }

    public List<ImpactPoint> impactPoints = new List<ImpactPoint>();
    public List<Vector3> islandPositions = new List<Vector3>();
    public float islandRadius = 5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }

    private float GetDynamicAmplitude(Vector3 position)
    {
        float amplitude = 0f;

        // Apply impact points
        foreach (var impact in impactPoints)
        {
            float distance = Vector3.Distance(position, impact.position);
            if (distance < impact.influenceRadius)
            {
                float influence = (1f - (distance / impact.influenceRadius)) * impact.maxAmplitude;
                amplitude += influence;
            }
        }

        // Reduce waves near islands
        foreach (var island in islandPositions)
        {
            float distanceToIsland = Vector3.Distance(position, island);
            if (distanceToIsland < islandRadius)
            {
                float islandEffect = (1f - (distanceToIsland / islandRadius));
                amplitude *= (1f - islandEffect);  
            }
        }

        return Mathf.Max(amplitude, 0f);
    }

    public Vector3 GetWaveDisplacement(Vector3 position)
    {
        Vector3 displacement = Vector3.zero;

        foreach (var impact in impactPoints)
        {
            Vector2 waveDirection = new Vector2(
                Mathf.Cos(impact.directionAngle * Mathf.Deg2Rad),
                Mathf.Sin(impact.directionAngle * Mathf.Deg2Rad)
            ).normalized;

            float dynamicAmplitude = GetDynamicAmplitude(position);
            float phase = Vector2.Dot(new Vector2(position.x, position.z), waveDirection) / impact.wavelength + Time.time * impact.speed;
            float waveHeight = dynamicAmplitude * Mathf.Sin(phase);
            float horizontalDisplacement = dynamicAmplitude * Mathf.Cos(phase);

            displacement.x += horizontalDisplacement * waveDirection.x;
            displacement.z += horizontalDisplacement * waveDirection.y;
            displacement.y += waveHeight;
        }

        return displacement;
    }
}
