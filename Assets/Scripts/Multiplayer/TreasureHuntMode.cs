using UnityEngine;

public class TreasureHuntMode : MonoBehaviour
{
    
    public GameObject Chest;
    public Vector3[] SpawnAreas = new Vector3[] { new Vector3(483.87f, 1.2f, 285.28f), new Vector3(461.65f,1.638f,403.25f), new Vector3(431.70f,1.52f,449.83f),
        new Vector3(442.13f,1.51f,414.39f), new Vector3(595.32f,1.71f,341.53f), new Vector3(595.32f,1.71f,341.53f), new Vector3(620.38f,1.52f,351.17f),
        new Vector3(543.33f,1.45f,617.4f), new Vector3(519.18f,1.24f,609.14f)
    };

    public void SpawnChest() 
    {
        Vector3 position = SpawnAreas[Random.Range(0, SpawnAreas.Length)];
        
        Instantiate(Chest, position, Quaternion.identity);
        Debug.Log(position);
    }
}
