using UnityEngine;
using UnityEngine.AI; 

public class RandomMovement : MonoBehaviour 
{
    [SerializeField] private float range = 5; 
    
    private NavMeshAgent agent;
    private Vector3 initialPosition;
    
    
    
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
    }

    
    void Update()
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
    
    
    
    
    
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
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
}
