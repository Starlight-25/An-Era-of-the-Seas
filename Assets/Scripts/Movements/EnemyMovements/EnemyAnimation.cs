using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAnimation : MonoBehaviour
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

    
    
    
    
    public void TriggerAttackAnimation() => Animator.SetTrigger($"Attack{Random.Range(1, 4)}");

    
    
    

    public void TriggerDeathAnimation() => Animator.SetTrigger("Death");
}