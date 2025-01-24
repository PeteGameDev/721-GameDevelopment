using UnityEngine;

//Initial script written using tutorial
//https://www.youtube.com/watch?v=l0emsAHIBjU&t=1s

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera sceneCam;
    Vector3 lastPosition;
    [SerializeField] LayerMask placementLayer;

    public Vector3 GetSelectedMapPosition(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCam.nearClipPlane;
        Ray ray = sceneCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, placementLayer)){
            lastPosition = hit.point;
        }
        return lastPosition;
    }
}
