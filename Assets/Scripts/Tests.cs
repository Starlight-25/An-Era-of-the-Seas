using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        Boat boat = new Boat();
        string boatstring = "";
        foreach (var b in boat.Load())
        {
            boatstring += $"Sword Name: {b.Name}, Rarity: {b.Rarity}, Max Level: {b.MaxLevel}, Price: {b.Price}\n";
        }
        Debug.Log(boatstring);

        
        
        
        
        Crew crew = new Crew();
        string crewstring = "";
        foreach (var c in crew.Load())
        {
            string statstring = "";
            foreach (string stat in c.Stats)
            {
                statstring += $"{stat},";
            }
            crewstring += $"Crew Name: {c.Name}, Rarity: {c.Rarity}, Max Level: {c.MaxLevel}, Price: {c.Price}, Stats: ({statstring})\n";
        }
        Debug.Log(crewstring);





        Stigma stigma = new Stigma();
        string stigmastring = "";
        foreach (var s in stigma.Load())
        {
            string statstring = "";
            foreach (string stat in s.Stats)
            {
                statstring += $"{stat},";
            }
            stigmastring += $"Crew Name: {s.Name}, Rarity: {s.Rarity}, Max Level: {s.MaxLevel}, PriceCoin: {s.PriceCoin}, PricePWD: {s.PricePWD}, Stats: ({statstring})\n";
        }
        Debug.Log(stigmastring);







        Sword sword = new Sword();
        string swordstring = "";
        foreach (var s in sword.Load())
        {
            string statstring = "";
            foreach (string stat in s.Stats)
            {
                statstring += $"{stat},";
            }
            swordstring +=  $"Crew Name: {s.Name}, Rarity: {s.Rarity}, Max Level: {s.MaxLevel}, PriceCoin: {s.Price}, Stats: ({statstring})\n";
        }
        Debug.Log(swordstring);







        Firearm firearm = new Firearm();
        string firearmstring = "";
        foreach (var f in firearm.Load())
        {
            string statstring = "";
            foreach (string stat in f.Stats)
            {
                statstring += $"{stat},";
            }
            firearmstring += $"Crew Name: {f.Name}, Rarity: {f.Rarity}, Max Level: {f.MaxLevel}, PriceCoin: {f.Price}, Stats: ({statstring})\n";
        }
        Debug.Log(firearmstring);
    }
}
