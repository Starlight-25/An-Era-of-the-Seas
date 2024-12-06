
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Items
{
    public class Weapon1
    {
        public string Name;
        public string Rarity;
        public int MaxLevel;
        public int Price;
        public List<string> Stats;
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public class Sword : Weapon1
    {
        public List<Sword> Load()
        {
            string path = Resources.Load<TextAsset>("Stats/items/weapon").text;
            var data =
                JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(path);
            var dataswords = data["Swords"];
            List<Sword> swordList = new List<Sword>();

            foreach (var swordDict in dataswords.Keys)
            {
                var sword = dataswords[swordDict];
                Sword newSword = new Sword()
                {
                    Name = swordDict,
                    Rarity = (string)sword["Rarity"],
                    MaxLevel = Convert.ToInt32(sword["Max Level"]),
                    Price = Convert.ToInt32(sword["Price"]),
                    Stats = ((JArray)sword["Stats"]).ToObject<List<string>>()
                };
                
                swordList.Add(newSword);
            }

            return swordList;
        }
    }















    public class Firearm : Weapon1
    {
        public List<Firearm> Load()
        {
            string path = Resources.Load<TextAsset>("Stats/items/weapon").text;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(path);
            var datafirearm = data["Guns"];
            List<Firearm> firearmList = new List<Firearm>();
            
            foreach (var gun in datafirearm.Keys)
            {
                var gunData = datafirearm[gun];
                Firearm newFirearm = new Firearm()
                {
                    Name = gun,
                    Rarity = (string)gunData["Rarity"],
                    MaxLevel = Convert.ToInt32(gunData["Max Level"]),
                    Price = Convert.ToInt32(gunData["Price"]),
                    Stats = ((JArray)gunData["Stats"]).ToObject<List<string>>()
                };
                
                firearmList.Add(newFirearm);
            }
            
            return firearmList;
        }
    }
}