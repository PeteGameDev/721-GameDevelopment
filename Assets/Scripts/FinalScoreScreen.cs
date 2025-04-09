using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalScoreScreen : MonoBehaviour
{
    public TMP_Text finalScore, finalGrade;
    public Toggle suspectToggle, weaponToggle;
    int scoreNum;
    void Start()
    {
        scoreNum = PlayerPrefs.GetInt("finalScore");
        finalScore.SetText(PlayerPrefs.GetInt("finalScore").ToString());
        if(PlayerPrefs.GetInt("TargetFound") == 1){
            suspectToggle.GetComponent<Toggle>().isOn = true;
        }
        if(PlayerPrefs.GetInt("WeaponFound") == 1){
            weaponToggle.GetComponent<Toggle>().isOn = true;
        }

        if(scoreNum <= 0){
            finalGrade.SetText("F");
        }
        if(scoreNum >= 1){
            finalGrade.SetText("A");
        }

    }

    public void ReturnToMenu(){
        SceneManager.LoadScene(0);
    }
}
