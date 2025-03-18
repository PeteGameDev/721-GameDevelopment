using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public void PlayButton(){
        SceneManager.LoadScene(1); //eventually have this load in a random scene
    }

    public void Quit(){
        Application.Quit();
    }
}
