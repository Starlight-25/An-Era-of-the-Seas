using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator Animator;

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
        bool JumpTrigger = Input.GetKeyDown(KeyCode.Space);
        if (JumpTrigger) Animator.SetTrigger("Jump" + (isRunning ? "Running" : "Idle"));
    }
}