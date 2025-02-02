using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapstanInteractor : MonoBehaviour
{

    public Transform InteractorSource; // Player camera
    public float InteractRange = 3f;
    
    public static bool isAnchored = true;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hit, InteractRange)) // Cast a ray to detect if the player is in range of the capstan.
            {
                if (hit.collider.gameObject.CompareTag("Capstan"))
                {
                    isAnchored = !isAnchored; 
                    // If the boat isn't already anchored, change the state of isAnchored, stopping the boat entirely, else change the state of isAnchored, allowing the boat to move.
                }
            }
        } 
        
    }
    
}
