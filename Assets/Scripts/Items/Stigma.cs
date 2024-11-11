using System.Collections.Generic;
using System.IO;
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
        public List<Stigma> Stigmata;
    }
    
    
    
    
    public class StigmaLoader{
        public List<Stigma> LoadStigma()
        {
            string path = Resources.Load<TextAsset>("Stats/items/stigma.json").text;
            JObject stigmaData = JObject.Parse(File.ReadAllText(path));
            StigmaList stigmaList = new StigmaList();
            foreach (var stigma in (JObject)stigmaData["Stigma"])
            {
                Stigma newStigma = new Stigma();
                newStigma.Name = stigma.Key;
                newStigma.Rarity = (string)stigma.Value["Rarity"];
                newStigma.MaxLevel = (int)stigma.Value["Max Level"];
                newStigma.PriceCoin = (int)stigmaData[newStigma.Rarity]["Price"]["Coins"];
                newStigma.PricePWD = (int)stigmaData[newStigma.Rarity]["Price"]["PWD"];
                newStigma.Stats = stigma.Value["Stats"].ToObject<List<string>>();

                stigmaList.Stigmata.Add(newStigma);
            }
            return stigmaList.Stigmata;
        }
    }
}