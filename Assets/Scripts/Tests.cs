using UnityEngine;
using Items;

public class Tests : MonoBehaviour
{
    void Start()
    {
        CrewLoader loader = new CrewLoader();
        CrewList gunlist = loader.LoadCrew();
        foreach (var boat in gunlist.Crews)
        {
            Debug.Log($"Boat Name: {boat.Name}, Rarity: {boat.Rarity}, MaxLevel: {boat.MaxLevel}, Price: {boat.Price}");
        }
    }
}
