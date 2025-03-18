using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class TutorialTextController : MonoBehaviour
{
    public Image tutorialImage;
    public TextMeshProUGUI tutorialTextBox;
    public string[] lines;
    public float textSpeed;
    int index;

    void Start()
    {   
        tutorialTextBox.text = string.Empty;
        StartDialogue();   
    }


    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            tutorialTextBox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index <lines.Length - 1){
            index++;
            tutorialTextBox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            gameObject.SetActive(false);
        }
    }

    public void ContinueButton(){
        if(tutorialTextBox.text == lines[index]){
            NextLine();
        }
        else{
            StopAllCoroutines();
            tutorialTextBox.text = lines[index];
        }
    }
}
