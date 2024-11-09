using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json.Linq;
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
    
    public class WeaponList
    {
        public List<Weapon> Swords;
        public List<Weapon> Guns;
    }
    
    
    
    
    
    
    
    
    public class SwordLoader
    {
        public List<Weapon> LoadSwords()
        {
            string path = Resources.Load<TextAsset>("Stats/items/weapon.json").text;
            JObject weaponData = JObject.Parse(File.ReadAllText(path));
            WeaponList swordList = new WeaponList();
            foreach (var sword in (JObject)weaponData["Swords"])
            {
                Weapon newSword = new Weapon();
                newSword.Name = sword.Key;
                newSword.Rarity = (string)sword.Value["Rarity"];
                newSword.MaxLevel = (int)weaponData["Rarity"][newSword.Rarity]["Max Level"];
                newSword.Price = (int)weaponData["Rarity"][newSword.Rarity]["Price"];
                newSword.Stats = sword.Value["Stats"].ToObject<List<string>>();
                
                swordList.Swords.Add(newSword);
            }
            return swordList.Swords;
        } 
    }








    
    public class GunLoader
    {
        public List<Weapon> LoadGuns()
        {
            string path = Resources.Load<TextAsset>("Stats/items/weapon.json").text;
            JObject weaponData = JObject.Parse(File.ReadAllText(path));
            WeaponList gunList = new WeaponList();
            foreach (var gun in (JObject)weaponData["Guns"])
            {
                Weapon newGun = new Weapon();
                newGun.Name = gun.Key;
                newGun.Rarity = (string)gun.Value["Rarity"];
                newGun.MaxLevel = (int)weaponData["Rarity"][newGun.Rarity]["Max Level"];
                newGun.Price = (int)weaponData["Rarity"][newGun.Rarity]["Price"];
                newGun.Stats = gun.Value["Stats"].ToObject<List<string>>();
                
                gunList.Guns.Add(newGun);
            }
            return gunList.Guns;
        }
    }
}