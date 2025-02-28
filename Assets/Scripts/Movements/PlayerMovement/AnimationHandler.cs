using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, GroundLayer);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        bool isFalling = !isGrounded && !isJumping;
        
        Animator.SetBool("isRunning", isRunning && !isOnWater);
        Animator.SetBool("IsJumping", isJumping);
        Animator.SetBool("IsGrounded", isGrounded);
        Animator.SetBool("IsFalling", isFalling);
        Animator.SetBool("IsOnWater", isOnWater);
        Animator.SetBool("IsSwimming", isOnWater && isRunning);
    }



    

    public void TrigerDeathAnimation() => Animator.SetTrigger("Death");


    
    
    
    public void TriggerAttackAnimation() => Animator.SetTrigger($"Attack{Random.Range(1, 4)}");
}