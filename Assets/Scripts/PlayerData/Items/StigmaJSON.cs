using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;


public class StigmaJSON
{
    public string Name;
    public string Rarity;
    public int MaxLevel;
    public int PriceCoin;
    public int PricePWD;
    public List<string> Stats;

    public List<StigmaJSON> Load()
    {
        string path = Resources.Load<TextAsset>("Stats/items/stigma").text;
        var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(path);
        List<StigmaJSON> stigmaList = new List<StigmaJSON>();
        
        foreach (var stigmaDict in data.Keys)
        {
            var stigma = data[stigmaDict];
            StigmaJSON newStigmaJson = new StigmaJSON()
            {
                Name = stigmaDict,
                Rarity = (string)stigma["Rarity"],
                MaxLevel = Convert.ToInt32(stigma["MaxLvl"]),
                PriceCoin = Convert.ToInt32(stigma["PriceCoins"]),
                PricePWD = Convert.ToInt32(stigma["PricePWD"]),
                Stats = ((JArray)stigma["Stats"]).ToObject<List<string>>()
            };
            
            stigmaList.Add(newStigmaJson);
        }

        return stigmaList;
    }
}