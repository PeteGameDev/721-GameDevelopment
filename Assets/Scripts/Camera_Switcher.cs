using UnityEngine;

public class Camera_Switcher : MonoBehaviour
{
    public int selectedCamera = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectCamera();
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
    }
}
