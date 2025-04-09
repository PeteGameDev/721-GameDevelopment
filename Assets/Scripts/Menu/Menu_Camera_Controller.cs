using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Menu_Camera_Controller : MonoBehaviour
{
    public float lookSpeed, minValue, maxValue;

    float rotationX, rotationY;
    public Camera cam;
    public GameObject sceneCameras, inGameCanvas, docObject;
    
    int x, y;
    bool folderOpen = false;
    
    void Start()
    {
        x = Screen.width / 2; 
        y = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //CameraRotate();
        if(Input.GetButtonDown("Fire1")){
            SelectObject();
        }

        if(folderOpen && Input.GetKeyDown(KeyCode.Escape)){
            CloseFolder();
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
        /*RaycastHit hit; 
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10f)){
            if(hit.collider.gameObject.tag == ("PC")){
                sceneCameras.SetActive(true);
                cam.gameObject.SetActive(false);
                inGameCanvas.SetActive(true);
                playerHubUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
            }

            if(hit.collider.gameObject.tag == ("Document")){
                OpenFolder();
            }
        }*/
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.nearClipPlane;
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            if(hit.collider.gameObject.tag == ("PC")){
                sceneCameras.SetActive(true);
                cam.gameObject.SetActive(false);
                inGameCanvas.SetActive(true);
                //playerHubUI.SetActive(false);
                //Cursor.lockState = CursorLockMode.None;
            }

            if(hit.collider.gameObject.tag == ("Document")){
                OpenFolder();
            }
        }
    }

    public void CloseFolder(){
        folderOpen = false;
        lookSpeed = 7.5f;
        //Cursor.lockState = CursorLockMode.Locked;
        //docObject.SetActive(false);
        docObject.transform.DOMove(new Vector3(x, -1500, 0), 1);
    }

    void OpenFolder(){
        folderOpen = true;
        //Cursor.lockState = CursorLockMode.None;
        lookSpeed = 0;
        //docObject.SetActive(true);
        docObject.transform.DOMove(new Vector3(x, y, 0), 1);
        
    }

    public void AbandonSearch(){
        SceneManager.LoadScene(3);
    }
}
