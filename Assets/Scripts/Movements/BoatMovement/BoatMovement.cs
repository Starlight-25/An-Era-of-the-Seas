using System;
using System.Linq.Expressions;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    public Rigidbody BoatBody;
    
    public float speed = 1f; // Should change according to wind...
    public float helmMovingSpeed = 10000f;

    private Vector3 EulerAngleVelocity = new Vector3(0, 1, 0);
    private float xRotation = 0f;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && HelmInteractor.inHelm && !CapstanInteractor.isAnchored)
        {
            MoveBoatForward(speed); 
        }
        
        if (HelmInteractor.inHelm) // If the player IS in the helm menu, then he can be able to move the boat.
        {
            xRotation = Input.GetAxis("Mouse X") * Time.deltaTime;
            
            MoveBoat();
        }
    }

    private void MoveBoat()
    {
        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * (xRotation * (helmMovingSpeed * Time.fixedDeltaTime)));
        
        BoatBody.MoveRotation(BoatBody.rotation * deltaRotation);
    }
    
    private void MoveBoatForward(float movementSpeed)
    {
        Vector3 movement = transform.TransformDirection(new Vector3(0,0, 1)) * movementSpeed;
        BoatBody.linearVelocity = new Vector3(movement.x, movement.y, movement.z);
    }
    
}
    
    /* Trigonometry of sailing: https://www.youtube.com/watch?v=_zDF40XFWN4
     
     Real life data for optimal angle between the wind and the sail, for optimal speed. (theta = 38°)
     Conducted at the University of Miami (Rosenstiel School of Marine and Atmospheric Science)
     
     To learn more, see pdf on Discord.
     
     */
