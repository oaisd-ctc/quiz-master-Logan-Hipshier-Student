using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]QuestionSO question;
    [SerializeField]GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField]Sprite defaultAnswerSprite;
    [SerializeField]Sprite correctAnswerSprite;
    void Start()
    {
        DisplayQuestion();   
    }

   public void OnAnswerSelected(int index){
        if(index== question.GetCorrectAnswerIndex()){
            questionText.text="Correct!";
            Image buttonImage =answerButtons[index].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
        }
        else{
            correctAnswerIndex=question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text=("Incorrect :( \n The Correct Answer is: " + correctAnswer);
            Image buttonImage =answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
        
        }
    SetButtonState(false);
   }
   void DisplayQuestion(){
        questionText.text=question.GetQuestion();
        for(int i = 0; i<answerButtons.Length; i++){
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text=question.GetAnswer(i);
        }

   }

void GetNextQuestion(){
    SetButtonState(true);
    DisplayQuestion();
}
void SetButtonState(bool state){
    for(int i = 0; i <answerButtons.Length;i++){
        Button button = answerButtons[i].GetComponent<Button>();
        button.interactable = state;
    }
}
void SetDefaultButtonSprite(){
    for(int i=0; i<answerButtons.Length; i++){
         Image buttonImage =answerButtons[i].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
    }

}
}

