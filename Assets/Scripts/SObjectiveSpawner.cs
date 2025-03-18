using UnityEngine;

public class SObjectiveSpawner : MonoBehaviour
{
    public GameObject[] SObjectiveSpawnPoints;
    public GameObject ObjectivePrefab;
    int number;
    
    void Start()
    {
        SObjectiveSpawnPoints = GameObject.FindGameObjectsWithTag("ObjectiveSP");  
        number = Random.Range(0, SObjectiveSpawnPoints.Length);
        Instantiate(ObjectivePrefab, SObjectiveSpawnPoints[number].transform);

    }

    
}
