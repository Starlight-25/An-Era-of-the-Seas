using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //Movement
    public CharacterController controller;
    public float speed = 12f; // Adjustable
    
    //Gravity
    public float gravity = -19.62f; // Two times earth gravity because it feels nicer, need to ajust.
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 2f; // Adjustable too
    
    Vector3 velocity;
    bool isGrounded;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (HelmInteractor.inHelm == false) // If the player is not in the helm menu.
        {
            //Movement 
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
        
            Vector3 move = transform.right * x + transform.forward * z;
        
            controller.Move(move * (speed * Time.deltaTime));
        
            //Gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
            // Resets velocity when grounded
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Not 0 to be sure that the player is REALLY on the ground
            }
        
            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(-2.0f * jumpHeight * gravity);
            }
        }
    }
}
