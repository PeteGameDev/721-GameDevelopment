using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using DG.Tweening;
public class NPC_Behaviour : MonoBehaviour
{
    float wanderRadius;
    float wanderTimer, otherNumber;
    int number;
    private Transform targetPosition;
    private NavMeshAgent agent;
    private float timer;
    public NPC_Information_SO npcInfoSO; 
    public GameObject[] NPCPrefabs;
    public Animator anims;
    [Range(1, 100)]
    public float maxWanderDistnace;
    
    void Awake(){
        wanderRadius = Random.Range(1, maxWanderDistnace);
        wanderTimer = Random.Range(1, 10);
        number = Random.Range(0, NPCPrefabs.Length);
        otherNumber = Random.Range(1.1f, 1.9f);
        otherNumber = Mathf.Round(otherNumber * 10.0f) * 0.1f;
        targetPosition = GameObject.Find("Target_Position").transform;
    }
    
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        NPCPrefabs[number].SetActive(true);
        if(npcInfoSO.isTarget == true){
            NPCPrefabs[number].GetComponent<Renderer>().material.DOTiling(new Vector2(otherNumber, 1), 1f);
            GameObject targetClone = Instantiate(this.transform.GetChild(0).gameObject, targetPosition.position, targetPosition.rotation);
            //targetClone.GetComponent<Renderer>().material.DOTiling(new Vector2(otherNumber, 1), 1f);
        }
        
        agent.speed = Random.Range(2, 4);
        
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
