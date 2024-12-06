using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Items
{
    public class Boat
    {
        public string Name;
        public string Rarity;
        public int MaxLevel;
        public int Price;

        public Boat()
        {
            
        }

        public List<Boat> Load()
        {
            string path = Resources.Load<TextAsset>("Stats/items/boat").text;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(path);
            List<Boat> boatlist = new List<Boat>();

            foreach (var boatDict in data.Keys)
            {
                var boat = data[boatDict];
                Boat newBoat = new Boat()
                {
                    Name = boatDict,
                    Rarity = (string)boat["Rarity"],
                    MaxLevel = Convert.ToInt32(boat["Max Level"]),
                    Price = Convert.ToInt32(boat["Price"])
                };
                
                boatlist.Add(newBoat);
            }

            return boatlist;
        }
    }
}