using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    public int finalScore, incorrectGuess, incorrectScore;
    public TMP_Text finalScoreText;
    public TMP_Text incorrectGuessText;

    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        //if(targetfound){finalscore + 1000}
        //if(sObjective){finalscore + 500}
        //finalscore = score - incorrect guesses 
        finalScoreText.SetText(finalScore.ToString());
        incorrectGuessText.SetText(incorrectGuess.ToString());
        PlayerPrefs.SetInt("finalScore", finalScore);
    }
}
