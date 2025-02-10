using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    public List<BoatJSON> BoatJSON;
    public List<CrewJSON> CrewJSON;
    public List<WeaponJSON> WeaponJSON;
    public List<StigmaJSON> StigmaJSON;

    private void Awake()
    {
       WeaponJSON = new WeaponJSON().Load();
       BoatJSON = new BoatJSON().Load();
       CrewJSON = new CrewJSON().Load();
       StigmaJSON = new StigmaJSON().Load();
       Debug.Log("JsonData Loaded");
    }

    
    
    
    
    public WeaponJSON GetWeapon(string Name)
    {
        return WeaponJSON.First(sword => sword.Name == Name);
    }
    
    public StigmaJSON GetStigma(string Name)
    {
        return StigmaJSON.First(stigma => stigma.Name == Name);
    }

    public BoatJSON GetBoat(string Name)
    {
        return BoatJSON.First(boat => boat.Name == Name);
    }

    public CrewJSON GetCrew(string Name, string Rarity)
    {
        return CrewJSON.First(crew => crew.Name == Name && crew.Rarity == Rarity);
    }
}
