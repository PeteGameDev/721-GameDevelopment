using UnityEngine;
using UnityEngine.UI;
public class Camera_Controller : MonoBehaviour
{
    float screenPixEdge = 10f;
    float min = 20f, max = 60f, cameraFOV;
    Camera sceneCam;
    public LayerMask targetLayer;
    public GameObject endScreen;

    void Start(){
        sceneCam = this.gameObject.GetComponent<Camera>();
        cameraFOV = 60f;
        
    }
    void Update()
    {   
        
        targetPerson();
        if(Input.GetKey(KeyCode.E) && cameraFOV <= max){
            cameraFOV++;
        }
        if(Input.GetKey(KeyCode.Q) && cameraFOV >= min){
            cameraFOV--;
        }
        
        sceneCam.fieldOfView = cameraFOV;
       
    }

    void targetPerson(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCam.nearClipPlane;
        Ray ray = sceneCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, targetLayer)){
            if(Input.GetButtonDown("Fire1")){
                //Debug.Log(hit.collider.name);
                if(hit.collider.gameObject.GetComponent<NPC_Behaviour>().npcInfoSO.isTarget == true){
                    Debug.Log("you win");
                    endScreen.SetActive(true);
                    Destroy(hit.collider.gameObject);
                }
            }
            
        }
    }

    
}   
