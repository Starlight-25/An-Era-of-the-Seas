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
}















public class SwordJSON : WeaponJSON
{
    public List<SwordJSON> Load()
    {
        string path = Resources.Load<TextAsset>("Stats/items/weapon").text;
        var data =
            JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(path);
        var dataswords = data["Swords"];
        List<SwordJSON> swordList = new List<SwordJSON>();

        foreach (var swordDict in dataswords.Keys)
        {
            var sword = dataswords[swordDict];
            SwordJSON newSwordJson = new SwordJSON()
            {
                Name = swordDict,
                Rarity = (string)sword["Rarity"],
                MaxLevel = Convert.ToInt32(sword["Max Level"]),
                Price = Convert.ToInt32(sword["Price"]),
                Stats = ((JArray)sword["Stats"]).ToObject<List<string>>()
            };
            
            swordList.Add(newSwordJson);
        }

        return swordList;
    }
}















public class FirearmJSON : WeaponJSON
{
    public List<FirearmJSON> Load()
    {
        string path = Resources.Load<TextAsset>("Stats/items/weapon").text;
        var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(path);
        var datafirearm = data["Firearms"];
        List<FirearmJSON> firearmList = new List<FirearmJSON>();
        
        foreach (var gun in datafirearm.Keys)
        {
            var gunData = datafirearm[gun];
            FirearmJSON newFirearmJson = new FirearmJSON()
            {
                Name = gun,
                Rarity = (string)gunData["Rarity"],
                MaxLevel = Convert.ToInt32(gunData["Max Level"]),
                Price = Convert.ToInt32(gunData["Price"]),
                Stats = ((JArray)gunData["Stats"]).ToObject<List<string>>()
            };
            
            firearmList.Add(newFirearmJson);
        }
        
        return firearmList;
    }
}