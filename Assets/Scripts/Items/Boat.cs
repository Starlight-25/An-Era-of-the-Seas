using System.Collections.Generic;
using System.IO;
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
        public List<Boat> Boats;
    }
    
    
    
    public class BoatLoader{
        public List<Boat> LoadBoat()
        {
            string path = Resources.Load<TextAsset>("Stats/items/boat.json").text;
            JObject boatData = JObject.Parse(File.ReadAllText(path));
            BoatList boatList = new BoatList();
            foreach (var boat in boatData)
            {
                Boat newBoat = new Boat();
                newBoat.Name = boat.Key;
                newBoat.Rarity = (string)boat.Value["Rarity"];
                newBoat.MaxLevel = (int)boat.Value["Max Level"];
                newBoat.Price = (int)boat.Value["Price"];
                
                boatList.Boats.Add(newBoat);
            }
            return boatList.Boats;
        }
    }
}