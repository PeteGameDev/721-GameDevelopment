using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    public GameObject levelScreen, mainScreen;
    public RawImage fadeToBlack;
    public AudioSource staticAudio;
    void Start(){
        fadeToBlack.DOFade(0f, 0.5f);
    }
    public void PlayButton(){
        mainScreen.SetActive(false);
        fadeToBlack.DOFade(255f, 0.01f);
        staticAudio.Play();
        levelScreen.SetActive(true);
        fadeToBlack.DOFade(0f, 0.5f);
        //SceneManager.LoadScene(1); //eventually have this load in a random scene
    }

    public void BackButton(){
        levelScreen.SetActive(false);
        fadeToBlack.DOFade(0f, 0.5f);
        staticAudio.Play(); 
        mainScreen.SetActive(true);
    }

     public void Quit(){
        Application.Quit();
    }

    public void LevelSelect(int sceneNumber){
        fadeToBlack.DOFade(255f, 0.5f);
        SceneManager.LoadScene(sceneNumber);
    }
}
