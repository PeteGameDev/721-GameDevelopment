using UnityEngine;
using System.Collections.Generic;
public class NPC_Spawning : MonoBehaviour
{
    GameObject[] spawnPoints, spawnedNPC;
    public NPC_Information_SO[] npcInfoScriptables;
    public GameObject regularNPC;
    public int maxNPC;

    List<GameObject> SpawnPoints = new List<GameObject>();
    void Awake()
    {
        maxNPC = Random.Range(5, 20);
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        SpawnPicker();
        
    }

    
    void Start(){
        spawnedNPC = GameObject.FindGameObjectsWithTag("NPC");
        //spawnedNPC[0].GetComponent<NPC_Behaviour>().npcInfoSO = npcInfoScriptables[0]; //traitor gets first in list
        for(int i = 0; i < spawnedNPC.Length; i++){
            spawnedNPC[i].GetComponent<NPC_Behaviour>().npcInfoSO = npcInfoScriptables[1];
        }
        spawnedNPC[Random.Range(0, spawnedNPC.Length)].GetComponent<NPC_Behaviour>().npcInfoSO = npcInfoScriptables[0];
        
    }
    void SpawnPicker()
    {
        for(int i = 0; i < spawnPoints.Length; i++){
            SpawnPoints.Add(spawnPoints[i]);
        }    
        for(int i = 0; i < SpawnPoints.Count; i++){
            SpawnPoints.RemoveAt(Random.Range(0, SpawnPoints.Count - 1));
        }
        SpawnNPC();
    }

    void SpawnNPC(){
        for(int i = 0; i < SpawnPoints.Count; i++){
            for(int j = 0; j < maxNPC; j++){
                Instantiate(regularNPC, SpawnPoints[i].transform);
            }
        }
    }
}
