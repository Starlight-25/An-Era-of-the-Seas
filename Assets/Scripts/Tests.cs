using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        SwordLoader swordLoader = new SwordLoader();
        var swords = swordLoader.LoadSwords();
        foreach (var sword in swords.Swords)
        {
            Debug.Log($"Sword Name: {sword.Name}, Rarity: {sword.Rarity}, Max Level: {sword.MaxLevel}, Price: {sword.Price}");
        }
    }
}
