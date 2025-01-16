using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    public List<BoatJSON> BoatJSON;
    public List<CrewJSON> CrewJSON;
    public List<SwordJSON> SwordJSON;
    public List<FirearmJSON> FirearmJSON;
    public List<StigmaJSON> StigmaJSON;

    private void Awake()
    {
       SwordJSON = new SwordJSON().Load();
       FirearmJSON = new FirearmJSON().Load();
       BoatJSON = new BoatJSON().Load();
       CrewJSON = new CrewJSON().Load();
       StigmaJSON = new StigmaJSON().Load();
       Debug.Log("JsonData Loaded");
    }

    
    
    
    
    public SwordJSON GetSword(string Name)
    {
        return SwordJSON.First(sword => sword.Name == Name);
    }


    public FirearmJSON GetFirearm(string Name)
    {
        return FirearmJSON.First(firearm => firearm.Name == Name);
    }
    public StigmaJSON GetStigma(string Name)
    {
        return StigmaJSON.First(stigma => stigma.Name == Name);
    }

    public BoatJSON GetBoat(string Name)
    {
        return BoatJSON.First(boat => boat.Name == Name);
    }

    public CrewJSON GetCrew(string Name)
    {
        return CrewJSON.First(crew => crew.Name == Name);
    }
}
