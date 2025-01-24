using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Camera sceneCam;
    public LayerMask targetLayer;
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
