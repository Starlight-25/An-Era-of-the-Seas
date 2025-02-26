    using System;
    using Unity.Netcode;
    using UnityEngine;

public class AnimationHandlerNetwork : NetworkBehaviour
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
        if (!IsOwner) return;

        bool isRunning = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
                         Input.GetKey(KeyCode.S);
        bool isOnWater = Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, 1.6f, WaterLayer);
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, GroundLayer);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        bool isFalling = !isGrounded && !isJumping;
        bool isSwimming = isOnWater && isRunning;
        
        UpdateAnimationServerRPC(isRunning, isOnWater, isGrounded, isJumping, isFalling, isSwimming);
    }


    [ServerRpc]
    private void UpdateAnimationServerRPC(bool isRunning, bool isOnWater, bool isGrounded, bool isJumping,
        bool isFalling, bool isSwimming)
    {
        UpdateAnimationClientRPC(isRunning, isOnWater, isGrounded, isJumping, isFalling, isSwimming);
    }


    [ClientRpc]
    private void UpdateAnimationClientRPC(bool isRunning, bool isOnWater, bool isGrounded, bool isJumping, bool isFalling, bool isSwimming)
    {
        Animator.SetBool("isRunning", isRunning && !isOnWater);
        Animator.SetBool("IsJumping", isJumping);
        Animator.SetBool("IsGrounded", isGrounded);
        Animator.SetBool("IsFalling", isFalling);
        Animator.SetBool("IsOnWater", isOnWater);
        Animator.SetBool("IsSwimming", isSwimming);
    }
}
