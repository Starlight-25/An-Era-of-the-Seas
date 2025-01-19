using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WeaponJSON
{
    public string Name;
    public string Rarity;
    public int MaxLevel;
    public int Price;
    public List<string> Stats;
    
    public List<WeaponJSON> Load()
    {
        string path = Resources.Load<TextAsset>("Stats/items/weapon").text;
        var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(path);
        List<WeaponJSON> weaponList = new List<WeaponJSON>();

        foreach (var swordDict in data.Keys)
        {
            var sword = data[swordDict];
            WeaponJSON newSwordJson = new WeaponJSON()
            {
                Name = swordDict,
                Rarity = (string)sword["Rarity"],
                MaxLevel = Convert.ToInt32(sword["Max Level"]),
                Price = Convert.ToInt32(sword["Price"]),
                Stats = ((JArray)sword["Stats"]).ToObject<List<string>>()
            };
            
            weaponList.Add(newSwordJson);
        }

        return weaponList;
    }
}