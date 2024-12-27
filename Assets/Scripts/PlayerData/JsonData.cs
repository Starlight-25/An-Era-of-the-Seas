using System;
using System.Collections.Generic;
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
       BoatJSON = new BoatJSON().Load();
       CrewJSON = new CrewJSON().Load();
       SwordJSON = new SwordJSON().Load();
       FirearmJSON = new FirearmJSON().Load();
       StigmaJSON = new StigmaJSON().Load();
       Debug.Log("JsonData Loaded");
    }
}
