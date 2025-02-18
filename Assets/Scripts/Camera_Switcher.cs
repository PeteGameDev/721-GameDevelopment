using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Camera_Switcher : MonoBehaviour
{
    public Image fadeToBlack;
    public int selectedCamera = 0;

    public GameObject sceneCameras, menuCamera, inGameCanvas, menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
        SelectCamera();
        fadeToBlack.DOFade(0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedCamera = selectedCamera;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedCamera >= transform.childCount -1)
                selectedCamera = 0;
            else
                selectedCamera++;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedCamera <= 0)
                selectedCamera = transform.childCount - 1;
            else
                selectedCamera--;
        }

        if(previousSelectedCamera != selectedCamera)
        {
            SelectCamera();
            fadeToBlack.DOFade(0f, 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.Locked;
            sceneCameras.SetActive(false);
            menuCamera.SetActive(true);
            inGameCanvas.SetActive(false);
            menuCanvas.SetActive(true);
        }
    }

    void SelectCamera()
    {
        int i = 0;
        foreach (Transform camera in transform)
        {
            if(i == selectedCamera) 
                camera.gameObject.SetActive(true);
            else 
                camera.gameObject.SetActive(false);
            i++;
        }
        fadeToBlack.DOFade(255f, 0.5f);
    }
}
