using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    float screenPixEdge = 10f;
    float panSpeed = 3f;
    Camera sceneCam;
    public LayerMask targetLayer;
    public GameObject endScreen;

    void Start(){
        sceneCam = this.gameObject.GetComponent<Camera>();
    }
    void Update()
    {
       targetPerson();
       //CameraControls();
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

    void CameraControls(){
        float rotationx = Input.mousePosition.x;
        float rotationy = Input.mousePosition.y;

        //rotationx = Mathf.Clamp(rotationx, -50f, 50f);
        //rotationy = Mathf.Clamp(rotationy, -10f, 30f);

        transform.localEulerAngles = new Vector3(rotationx * panSpeed, rotationy * panSpeed, 0);
    }
}   
