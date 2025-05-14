using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManagerNetwork : NetworkBehaviour
{
    [SerializeField] private GameObject waterTilePrefab;
    [SerializeField] private int gridSizeX = 10;
    [SerializeField] private int gridSizeZ = 10;
    [SerializeField] private float tileSize = 10f;

    private class PlayerWaterGrid
    {
        public Transform playerTransform;
        public List<GameObject> waterTiles = new List<GameObject>();
        public Vector3 lastPlayerPosition;
    }

    private List<PlayerWaterGrid> playerGrids = new List<PlayerWaterGrid>();

    public void Initialize()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            PlayerWaterGrid grid = new PlayerWaterGrid();
            grid.playerTransform = player.transform;
            grid.lastPlayerPosition = player.transform.position;

            GenerateWaterGridForPlayer(grid);
            playerGrids.Add(grid);
        }
    }

    private void Update()
    {
        foreach (PlayerWaterGrid grid in playerGrids)
        {
            if (Vector3.Distance(grid.playerTransform.position, grid.lastPlayerPosition) > tileSize)
            {
                UpdateWaterGridForPlayer(grid);
                grid.lastPlayerPosition = grid.playerTransform.position;
            }
        }
    }

    private void GenerateWaterGridForPlayer(PlayerWaterGrid grid)
    {
        Vector3 playerPosition = grid.playerTransform.position;
        for (int x = -gridSizeX / 2; x < gridSizeX / 2; x++)
        {
            for (int z = -gridSizeZ / 2; z < gridSizeZ / 2; z++)
            {
                Vector3 spawnPosition = new Vector3(playerPosition.x + x * tileSize, 0, playerPosition.z + z * tileSize);
                GameObject waterTile = Instantiate(waterTilePrefab, spawnPosition, Quaternion.identity, transform);
                waterTile.GetComponent<NetworkObject>().Spawn();
                grid.waterTiles.Add(waterTile);
            }
        }
    }

    private void UpdateWaterGridForPlayer(PlayerWaterGrid grid)
    {
        Vector3 playerPosition = grid.playerTransform.position;
        int index = 0;

        for (int x = -gridSizeX / 2; x < gridSizeX / 2; x++)
        {
            for (int z = -gridSizeZ / 2; z < gridSizeZ / 2; z++)
            {
                Vector3 newPosition = new Vector3(playerPosition.x + x * tileSize, 0, playerPosition.z + z * tileSize);
                grid.waterTiles[index].transform.position = newPosition;
                index++;
            }
        }
    }
}