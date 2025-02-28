using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    [SerializeField] private GameObject waterTilePrefab; 
    [SerializeField] private int gridSizeX = 10; // Number of tiles in X direction
    [SerializeField] private int gridSizeZ = 10; // Number of tiles in Z direction
    [SerializeField] private float tileSize = 10f; // Size of each tile
    public Transform player; // Reference to the player (because i don't have the player on this branch)

    private List<GameObject> waterTiles = new List<GameObject>();
    private Vector3 lastPlayerPosition;

    private void Start()
    {
        GenerateWaterGrid();
        lastPlayerPosition = player.position;
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, lastPlayerPosition) > tileSize)
        {
            UpdateWaterGrid();
            lastPlayerPosition = player.position;
        }
    }

    private void GenerateWaterGrid()
    {
        if (waterTilePrefab == null)
        {
            Debug.LogError("Water tile prefab is not assigned!");
            return;
        }

        for (int x = -gridSizeX / 2; x < gridSizeX / 2; x++)
        {
            for (int z = -gridSizeZ / 2; z < gridSizeZ / 2; z++)
            {
                Vector3 spawnPosition = new Vector3(x * tileSize, 0, z * tileSize);
                GameObject waterTile = Instantiate(waterTilePrefab, spawnPosition, Quaternion.identity, transform);
                waterTiles.Add(waterTile);
            }
        }

        Debug.Log("Total water tiles instantiated: " + waterTiles.Count);
    }

    private void UpdateWaterGrid()
    {
        Vector3 playerPosition = player.position;
        int index = 0;

        for (int x = -gridSizeX / 2; x < gridSizeX / 2; x++)
        {
            for (int z = -gridSizeZ / 2; z < gridSizeZ / 2; z++)
            {
                Vector3 newPosition = new Vector3(playerPosition.x + x * tileSize, 0, playerPosition.z + z * tileSize);
                waterTiles[index].transform.position = newPosition;
                index++;
            }
        }

        Debug.Log("Water grid updated.");
    }
}