using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using DG.Tweening;
public class NPC_Behaviour : MonoBehaviour
{
    float wanderRadius;
    float wanderTimer;
    int number, otherNumber;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public NPC_Information_SO npcInfoSO; 
    public GameObject[] NPCPrefabs;
    public Animator anims;
    
    void Awake(){
        wanderRadius = Random.Range(1, 100);
        wanderTimer = Random.Range(1, 10);
        number = Random.Range(0, NPCPrefabs.Length);
    }
    
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        gameObject.GetComponent<Renderer>().material.color = npcInfoSO.NPCcolor;
        NPCPrefabs[number].SetActive(true);
        if(npcInfoSO.isTarget == true){
            NPCPrefabs[number].GetComponent<Renderer>().material.DOTiling(new Vector2(Random.Range(1.1f, 1.9f), 1), 1f);
        }
        
        
        
    }  
    
    void Update () {
        timer += Time.deltaTime;
        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
        float speed = agent.velocity.magnitude;
        anims.SetFloat("Speed", speed);
    }
    public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
           
            randomDirection += origin;
           
            NavMeshHit navHit;
           
            NavMesh.SamplePosition (randomDirection, out navHit, distance, layermask);
           
            return navHit.position;
        }

}
