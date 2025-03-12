using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private GameObject Needles;
    [SerializeField] private Transform Player;
    
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(Player.position.y);
    }
}
