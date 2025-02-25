using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator Animator;
    [SerializeField] private LayerMask GroundLayer;
    
    
    
    
    private void Start()
    {
        Animator = transform.Find("Pirate").GetComponent<Animator>();
    }

    
    
    
    
    private void Update()
    {
        bool isRunning = Animator.GetBool("isRunning");
        bool RunTrigger = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
                          Input.GetKey(KeyCode.S);
        
        
        Animator.SetBool("isRunning", RunTrigger);
        Jump(isRunning);
    }

    
    
    
    
    private void Jump(bool isRunning)
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, GroundLayer);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        bool isFalling = !isGrounded && !isJumping;
        Animator.SetBool("IsJumping", isJumping);
        Animator.SetBool("IsGrounded", isGrounded);
        Animator.SetBool("IsFalling", isFalling);
    }
}