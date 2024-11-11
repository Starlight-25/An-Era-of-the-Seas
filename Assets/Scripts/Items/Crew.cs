using System.Collections.Generic;
using System.IO;
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
        public List<Crew> Crews;
    }








    
    
    public class CrewLoader
    {
        public List<Crew> LoadCrew()
        {
            string path = Resources.Load<TextAsset>("Stats/items/crew.json").text;
            JObject crewData = JObject.Parse(File.ReadAllText(path));
            CrewList crewList = new CrewList();
            foreach (var crew in (JObject)crewData["Crew"])
            {
                foreach (var rarity in (JObject)crewData["Rarity"])
                {
                    Crew newCrew = new Crew();
                    newCrew.Name = crew.Key;
                    newCrew.Rarity = rarity.Key;
                    newCrew.MaxLevel = (int)rarity.Value["Max Level"];
                    newCrew.Price = (int)rarity.Value["Price"];
                    newCrew.Stats = crew.Value["Stats"].ToObject<List<string>>();
                    
                    crewList.Crews.Add(newCrew);
                }
            }
            return crewList.Crews;
        }
    }
}