using System;
using System.Collections.Generic;
using System.IO;
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
    }

    public class CrewList
    {
        public List<Crew> Crews = new List<Crew>();
    }








    
    
    public class CrewLoader
    {
        public CrewList LoadCrew()
        {
            string path = Resources.Load<TextAsset>("Stats/items/crew").text;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(path);
            var datararity = data["Rarity"];
            var datacrew = data["Crew"];
            CrewList crewList = new CrewList();
            foreach (var rarity in datararity.Keys)
            {
                var rarityData = datararity[rarity];
                foreach (var crew in datacrew.Keys)
                {
                    var crewData = datacrew[crew];
                    Crew newCrew = new Crew();
                    
                    newCrew.Name = crew;
                    newCrew.Rarity = rarity;
                    newCrew.MaxLevel = Convert.ToInt32(rarityData["Max Level"]);
                    newCrew.Price = Convert.ToInt32(rarityData["Price"]);
                    newCrew.Stats = ((JArray)crewData["Stats"]).ToObject<List<string>>();
                    
                    crewList.Crews.Add(newCrew);
                }
            }
            return crewList;
        }
    }
}