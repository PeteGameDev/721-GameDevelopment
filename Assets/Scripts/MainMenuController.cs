using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject levelScreen;
    public void PlayButton(){
        levelScreen.SetActive(true);
        //SceneManager.LoadScene(1); //eventually have this load in a random scene
    }

    public void BackButton(){
        levelScreen.SetActive(false);  
    }

    public void Quit(){
        Application.Quit();
    }

    public void LevelSelect(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
    }
}
