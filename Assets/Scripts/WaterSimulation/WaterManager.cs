using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Vector3[] baseVertices;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        baseVertices = meshFilter.mesh.vertices;
    }

    private void Update()
    {
        Vector3[] vertices = new Vector3[baseVertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldPosition = transform.TransformPoint(baseVertices[i]);
            Vector3 waveDisplacement = WaveManager.instance.GetWaveDisplacement(worldPosition);
            vertices[i] = baseVertices[i] + transform.InverseTransformVector(waveDisplacement);
        }
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
