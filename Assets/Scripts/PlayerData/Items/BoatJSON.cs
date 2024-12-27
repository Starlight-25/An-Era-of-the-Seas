using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
public class BoatJSON
{
    public string Name;
    public string Rarity;
    public int MaxLevel;
    public int Price;

    public List<BoatJSON> Load()
    {
        string path = Resources.Load<TextAsset>("Stats/items/boat").text;
        var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(path);
        List<BoatJSON> boatlist = new List<BoatJSON>();

        foreach (var boatDict in data.Keys)
        {
            var boat = data[boatDict];
            BoatJSON newBoatJson = new BoatJSON()
            {
                Name = boatDict,
                Rarity = (string)boat["Rarity"],
                MaxLevel = Convert.ToInt32(boat["Max Level"]),
                Price = Convert.ToInt32(boat["Price"])
            };
            
            boatlist.Add(newBoatJson);
        }

        return boatlist;
    }
}