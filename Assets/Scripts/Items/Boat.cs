using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Items
{
    public class Boat
    {
        public string Name;
        public string Rarity;
        public int MaxLevel;
        public int Price;
    }
    
    public class BoatList{
        public List<Boat> Boats = new List<Boat>();
    }
    
    
    
    public class BoatLoader{
        public BoatList LoadBoat()
        {
            string path = Resources.Load<TextAsset>("Stats/items/boat").text;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(path);
            BoatList boatList = new BoatList();
            foreach (var boat in data.Keys)
            {
                var boatData = data[boat];
                Boat newBoat = new Boat();
                
                newBoat.Name = boat;
                newBoat.Rarity = (string)boatData["Rarity"];
                newBoat.MaxLevel = Convert.ToInt32(boatData["Max Level"]);
                newBoat.Price = Convert.ToInt32(boatData["Price"]);
                
                boatList.Boats.Add(newBoat);
            }
            return boatList;
        }
    }
}