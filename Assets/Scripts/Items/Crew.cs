using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Items
{
    public class Crew
    {
        public string Name;
        public string Rarity;
        public int MaxLevel;
        public int Price;
        public List<string> Stats;

        public List<Crew> Load()
        {
            string path = Resources.Load<TextAsset>("Stats/items/crew").text;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(path);
            var datararity = data["Rarity"];
            var datacrew = data["Crew"];
            List<Crew> crewList = new List<Crew>();
            
            foreach (var rarityDict in datararity.Keys)
            {
                var rarity = datararity[rarityDict];
                
                foreach (var crewDict in datacrew.Keys)
                {
                    var crew = datacrew[crewDict];
                    Crew newCrew = new Crew()
                    {
                        Name = crewDict,
                        Rarity = rarityDict,
                        MaxLevel = Convert.ToInt32(rarity["Max Level"]),
                        Price = Convert.ToInt32(rarity["Price"]),
                        Stats = ((JArray)crew["Stats"]).ToObject<List<string>>()
                    };
                    
                    crewList.Add(newCrew);
                }
            }

            return crewList;
        }

    }
}