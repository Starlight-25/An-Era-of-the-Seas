using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Items
{
    public class Stigma
    {
        public string Name;
        public string Rarity;
        public int MaxLevel;
        public int PriceCoin;
        public int PricePWD;
        public List<string> Stats;
    }
    
    public class StigmaList
    {
        public List<Stigma> Stigmata = new List<Stigma>();
    }
    
    
    
    
    public class StigmaLoader{
        public StigmaList LoadStigma()
        {
            string path = Resources.Load<TextAsset>("Stats/items/stigma").text;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(path);
            StigmaList stigmaList = new StigmaList();
            foreach (var stigma in data.Keys)
            {
                var stigmaData = data[stigma];
                Stigma newStigma = new Stigma();
                
                newStigma.Name = stigma;
                newStigma.Rarity = (string)stigmaData["Rarity"];
                newStigma.MaxLevel = Convert.ToInt32(stigmaData["MaxLvl"]);
                newStigma.PriceCoin = Convert.ToInt32(stigmaData["PriceCoins"]);
                newStigma.PricePWD = Convert.ToInt32(stigmaData["PricePWD"]);
                newStigma.Stats = ((JArray)stigmaData["Stats"]).ToObject<List<string>>();
                
                stigmaList.Stigmata.Add(newStigma);
            }

            return stigmaList;
        }
    }
}