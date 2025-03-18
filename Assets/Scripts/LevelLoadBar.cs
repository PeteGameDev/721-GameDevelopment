using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelLoadBar : MonoBehaviour
{
    public Slider loadSlider;
    public GameObject inGameMenu;
   

    void Start()
    {
        loadSlider.maxValue = 100; 
        InvokeRepeating("AddLoad", 0.1f, Random.Range(1, 3)); 
        //Cursor.lockState = CursorLockMode.Locked;  
    }

    void Update(){
        if(loadSlider.value >= loadSlider.maxValue){
            transform.DOScale(0, 0.2f);
            Invoke("ChangeMenu", 0.2f);
            
            
        }
        
    }
    void AddLoad(){
        loadSlider.value += Random.Range(10, 20);
    }

    void ChangeMenu(){
        inGameMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    
}
