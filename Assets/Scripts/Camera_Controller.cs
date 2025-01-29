using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    Camera sceneCam;
    public LayerMask targetLayer;

    void Start(){
        sceneCam = this.gameObject.GetComponent<Camera>();
    }
    void Update()
    {
       targetPerson();
    }

    void targetPerson(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCam.nearClipPlane;
        Ray ray = sceneCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, targetLayer)){
            if(Input.GetButtonDown("Fire1")){
                Debug.Log(hit.collider.name);
            }
            
        }
    }
}   
