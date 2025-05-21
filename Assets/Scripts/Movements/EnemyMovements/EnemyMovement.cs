using UnityEngine;
using UnityEngine.AI; 

public class EnemyMovement : MonoBehaviour 
{
    [SerializeField] private float range = 5; 
    private NavMeshAgent agent;
    private Vector3 initialPosition;
    private Transform Player;
    
    
    
    
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
        Player = GameObject.Find("Player").transform;
    }

    
    
    
    
    private void Update()
    {
        float distance = Vector3.Distance(Player.position, initialPosition);
        
        if (HandleOptimization(distance)) return;
        
        if (PLayer_in_range(distance))
        {
            agent.SetDestination(GetStoppingPosition(2f));   
        }
        else
        {
            if(agent.remainingDistance <= agent.stoppingDistance) 
            {
                Vector3 point;
                if (RandomPoint(initialPosition, range, out point)) 
                {
                    agent.SetDestination(point);
                }
            }
        }
    }

    private bool HandleOptimization(float distance)
    {
        if (distance > 100f)
        {
            if (agent.enabled) agent.enabled = false;
            return true;
        }
        if (!agent.enabled) agent.enabled = true;
        return false;
    }
    
    
    
    
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        { 
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }





    private bool PLayer_in_range(float distance) => distance <= range * 3;


    
    
    
    private Vector3 GetStoppingPosition(float stopDistance)
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Vector3 targetPosition = Player.position - direction * stopDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, range * 3, NavMesh.AllAreas)) return hit.position;
        return transform.position;
    }
}
