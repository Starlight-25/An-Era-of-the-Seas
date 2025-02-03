using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmInteractor : MonoBehaviour
{

    public Transform InteractorSource; // Player camera
    public float InteractRange = 3f;
    public GameObject Player;
    
    // So to choose the correct camera to start the game from.
    public Camera PlayerCamera;
    public Camera HelmCamera;

    public static bool inHelm = false; // Anchored by default

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inHelm) // First check if the player is not already helming the boat.
            {
                Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                if (Physics.Raycast(r, out RaycastHit hit, InteractRange))
                {
                    if (hit.collider.gameObject.tag == "Helm") // Checks that the object is the helm
                    {
                        SwitchCameras(); 
                    }
                }
            }
            else
            {
                SwitchCameras();
            }
        }
    }
    
    
    private void SwitchCameras() // Switch from the player camera to the helm camera, from where he can move the boat.
    {
        inHelm = !inHelm;
        
        PlayerCamera.enabled = !PlayerCamera.enabled;
        HelmCamera.enabled = !HelmCamera.enabled;
    }
    
    
}
