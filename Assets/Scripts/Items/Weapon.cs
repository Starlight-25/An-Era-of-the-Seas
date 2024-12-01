using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Items
{
    public class Weapon
    {
        public string Name;
        public string Rarity;
        public int MaxLevel;
        public int Price;
        public List<string> Stats;
    }
    

    public class SwordList
    {
        public List<Weapon> Swords = new List<Weapon>();
    }
    public class GunList
    {
        public List<Weapon> Guns = new List<Weapon>();
    }
    
    
    
    
    
    
    
    
    public class SwordLoader
    {
        public SwordList LoadSwords()
        {
            string path = Resources.Load<TextAsset>("Stats/items/weapon").text;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(path);
            var dataswords = data["Swords"];
            SwordList swordList = new SwordList();
            foreach (var sword in dataswords.Keys)
            {
                var swordData = dataswords[sword];
                Weapon newSword = new Weapon();
                
                newSword.Name = sword;
                newSword.Rarity = (string)swordData["Rarity"];
                newSword.MaxLevel = Convert.ToInt32(swordData["Max Level"]);
                newSword.Price = Convert.ToInt32(swordData["Price"]);
                newSword.Stats = ((JArray)swordData["Stats"]).ToObject<List<string>>();
                
                swordList.Swords.Add(newSword);
            }
            return swordList;
        } 
    }








    
    public class GunLoader
    {
        public GunList LoadGuns()
        {
            string path = Resources.Load<TextAsset>("Stats/items/weapon").text;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, object>>>>(path);
            var dataguns = data["Guns"];
            GunList gunList = new GunList();
            foreach (var gun in dataguns.Keys)
            {
                var gunData = dataguns[gun];
                Weapon newGun = new Weapon();
                
                newGun.Name = gun;
                newGun.Rarity = (string)gunData["Rarity"];
                newGun.MaxLevel = Convert.ToInt32(gunData["Max Level"]);
                newGun.Price = Convert.ToInt32(gunData["Price"]);
                newGun.Stats = ((JArray)gunData["Stats"]).ToObject<List<string>>();
                
                gunList.Guns.Add(newGun);
            }
            return gunList;
        }
    }
}