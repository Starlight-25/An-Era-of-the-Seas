using System;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimationHandler : MonoBehaviour
{
    private Animator Animator;
    private NavMeshAgent agent;

    
    
    

    private void Start()
    {
        Animator = transform.GetComponent<Animator>();
        agent = transform.GetComponent<NavMeshAgent>();
    }


    
    
    
    private void Update()
    {
        bool isMoving = agent.velocity.magnitude > 0.1f;
        Animator.SetBool("IsMoving", isMoving);
    }
}