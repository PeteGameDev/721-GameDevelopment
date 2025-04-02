using UnityEngine;
using UnityEngine.AI;

public class PoliceController : MonoBehaviour
{
    NavMeshAgent polAgent;
    public Animator anims;
    public GameObject particleObject;
    void Start()
    {
        polAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        float speed = polAgent.velocity.magnitude;
        anims.SetFloat("Speed", speed);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something in Trigger");
        if(other.gameObject.GetComponent<NPC_Behaviour>().npcInfoSO.isTarget == true){
            Debug.Log("next to target"); 
            GameObject clone = Instantiate(particleObject, this.transform);
            Destroy(gameObject, 0.1f);
            Destroy(other.gameObject, 0.1f);
            Destroy(clone, 1f);
            
        }
             
    }
}
