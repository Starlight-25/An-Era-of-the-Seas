using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData PlayerData;
    private string savePath;
    public void LoadPlayerData()
    {
        PlayerData = JsonConvert.DeserializeObject<PlayerData>(System.IO.File.ReadAllText(savePath));
    }
    
    public void SavePlayerData()
    {
        string updateData = JsonConvert.SerializeObject(PlayerData, Formatting.Indented);
        System.IO.File.WriteAllText(savePath, updateData);
    }
    
    public void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        LoadPlayerData();
    }
}