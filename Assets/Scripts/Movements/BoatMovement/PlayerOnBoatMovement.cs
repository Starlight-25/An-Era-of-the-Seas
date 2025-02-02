using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // The purpose of this class is to make the player move along the moving boat.
    
    // THIS DOESN'T WORK YET (HELP ME PAR PITIE)

    [SerializeField] string PlayerTag = "Player";
    [SerializeField] Transform Boat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            other.gameObject.transform.parent = Boat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            other.gameObject.transform.parent = null;
        }
    }
}
