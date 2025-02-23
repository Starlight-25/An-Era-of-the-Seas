using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController controller;
    [SerializeField] private float speed = 12f; // Adjustable
    
    //Gravity
    [SerializeField] private float gravity = -9.81f; // Two times earth gravity because it feels nicer, need to ajust.
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 1f; // Adjustable too
    
    Vector3 velocity;
    bool isGrounded;
    
    
    
    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    
    
    
    
    void Update()
    {
        if (BoatState.inHelm == false) // If the player is not in the helm menu.
        {
            //Movement 
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
        
            Vector3 move = transform.right * x + transform.forward * z;
        
            controller.Move(move * (speed * Time.deltaTime));
        
            //Gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        
            isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        
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
            
            Rotation();
        }
    }

    
    
    
    
    private int GetRotationAngle()
    {
        if (Input.GetKey(KeyCode.D)) return 90;
        if (Input.GetKey(KeyCode.A)) return -90;
        if (Input.GetKey(KeyCode.S)) return 180;
        return 0;
    }
    
    private void Rotation()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S))
        {
            float targetRotationY = transform.eulerAngles.y + GetRotationAngle();

            float newRotationY = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotationY, 50f * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, newRotationY, 0);
        }
    }
}
