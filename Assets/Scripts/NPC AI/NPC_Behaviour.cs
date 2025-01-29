using UnityEngine;
using UnityEngine.AI;

public class NPC_Behaviour : MonoBehaviour
{
    float wanderRadius;
    float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    void Awake(){
        wanderRadius = Random.Range(1, 100);
        wanderTimer = Random.Range(1, 10);
    }
    
    void OnEnable () {
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;
    }
  
    
    void Update () {
        timer += Time.deltaTime;

        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }
    public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
           
            randomDirection += origin;
           
            NavMeshHit navHit;
           
            NavMesh.SamplePosition (randomDirection, out navHit, distance, layermask);
           
            return navHit.position;
        }

}
