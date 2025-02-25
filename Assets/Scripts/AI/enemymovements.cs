using UnityEngine;
using UnityEngine.AI; 

public class enemymovements : MonoBehaviour 
{
    
     
    private float range = 5; 
    private NavMeshAgent agent;
    private Vector3 initialPosition;
    public GameObject player;
    
    
    
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
    }

    
    void Update()
    {   
        if (PLayer_in_range(player,initialPosition))
        {
            agent.SetDestination(player.transform.position);   
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

    bool PLayer_in_range(GameObject player , Vector3 bot)
    {
        if (Vector3.Distance(player.transform.position,bot) <= range*10 )
        {
            return true;
        }
        return false;
    }
    
}
