using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Menu_Camera_Controller : MonoBehaviour
{
    public float lookSpeed, minValue, maxValue;

    float rotationX, rotationY;
    public Camera cam;
    public GameObject sceneCameras, inGameCanvas, menuCanvas, docObject;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotate();
        if(Input.GetButtonDown("Fire1")){
            SelectObject();
        }
        
    }

    void CameraRotate(){
        rotationX += Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY += Input.GetAxis("Mouse X") * lookSpeed;

        rotationX = Mathf.Clamp(rotationX, minValue, maxValue);
        rotationY = Mathf.Clamp(rotationY, minValue, maxValue);

        transform.localEulerAngles = new Vector3(-rotationX, rotationY,0);
    }

    void SelectObject(){
        RaycastHit hit; 
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10f)){
            if(hit.collider.gameObject.tag == ("PC")){
                sceneCameras.SetActive(true);
                cam.gameObject.SetActive(false);
                inGameCanvas.SetActive(true);
                menuCanvas.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
            }

            if(hit.collider.gameObject.tag == ("Document")){
                OpenFolder();
            }
        }
    }

    public void CloseFolder(){
        lookSpeed = 7.5f;
        Cursor.lockState = CursorLockMode.Locked;
        docObject.SetActive(false);
    }

    void OpenFolder(){
        Cursor.lockState = CursorLockMode.None;
        lookSpeed = 0;
        docObject.SetActive(true);
        
    }
}
