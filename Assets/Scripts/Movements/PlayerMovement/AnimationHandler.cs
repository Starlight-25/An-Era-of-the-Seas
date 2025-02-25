using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator Animator;
    private LayerMask GroundLayer;
    private LayerMask WaterLayer;
    
    
    
    
    private void Start()
    {
        GroundLayer = LayerMask.GetMask("Ground");
        WaterLayer = LayerMask.GetMask("Water");
        Animator = transform.Find("Pirate").GetComponent<Animator>();
    }

    
    
    
    
    private void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
                          Input.GetKey(KeyCode.S);
        bool isOnWater = Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, 1.6f, WaterLayer);
        
        
        Animator.SetBool("isRunning", isRunning && !isOnWater);
        Jump();
        Swim(isRunning, isOnWater);
    }

    
    
    
    
    private void Jump()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, GroundLayer);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        bool isFalling = !isGrounded && !isJumping;
        Animator.SetBool("IsJumping", isJumping);
        Animator.SetBool("IsGrounded", isGrounded);
        Animator.SetBool("IsFalling", isFalling);
    }

    private void Swim(bool isRunning, bool isOnWater)
    {
        Animator.SetBool("IsOnWater", isOnWater);
        Animator.SetBool("IsSwimming", isOnWater && isRunning);
    }
}