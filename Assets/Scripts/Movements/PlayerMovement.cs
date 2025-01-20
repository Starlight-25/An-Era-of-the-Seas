using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    // Movement
    public CharacterController controller;
    public float speed = 12f; // Adjustable

    // Gravity
    public float gravity = -19.62f; // Two times earth gravity because it feels nicer
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 2f; // Adjustable too

    private Vector3 velocity;
    private bool isGrounded;

    void Update()
    {
        // Ensure only the owner of the object can control it
        if (!IsOwner) return;

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (speed * Time.deltaTime));

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative to keep the player grounded
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2.0f * jumpHeight * gravity);
        }
    }

    // Ensure this script only works for the object owned by the player
    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            // Disable components that should only work for the owner
            controller.enabled = false; // Disable CharacterController for non-owners
        }
    }
}