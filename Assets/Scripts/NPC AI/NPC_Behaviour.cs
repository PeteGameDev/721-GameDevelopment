using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class NPC_Behaviour : MonoBehaviour
{
    float wanderRadius;
    float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public NPC_Information_SO npcInfoSO; 
    public GameObject headItem;
    void Awake(){
        wanderRadius = Random.Range(1, 100);
        wanderTimer = Random.Range(1, 10);
        
    }
    
    void Start() {
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;
        gameObject.GetComponent<Renderer>().material.color = npcInfoSO.NPCcolor;
        //Instantiate(npcInfoSO.headItem[Random.Range(0, npcInfoSO.headItem.Length)], headItem.transform.position, headItem.transform.rotation);
        if(npcInfoSO.isTarget == true){
            headItem.SetActive(true);
        }
        
        
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
