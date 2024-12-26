using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlayerData PlayerData;
    public string savePath;
    public void LoadPlayerData()
    {
        PlayerData = JsonConvert.DeserializeObject<PlayerData>(System.IO.File.ReadAllText(savePath));
    }

    public void SavePlayerData()
    {
        string updateData = JsonUtility.ToJson(PlayerData, true);
        System.IO.File.WriteAllText(savePath, updateData);
    }
    
    public void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        LoadPlayerData();
    }
}
