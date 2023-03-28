using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField]TextMeshProUGUI questionText;
    QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questions;
    [Header("Answers")]
    [SerializeField]GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;
    [Header("Buttons")]
    [SerializeField]Sprite defaultAnswerSprite;
    [SerializeField]Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    TImer timer;
    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;
    
    
    void Awake()
    {
        timer=FindObjectOfType<TImer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue=questions.Count;
        progressBar.value=0;
       
      
    }
    void Update(){
        timerImage.fillAmount= timer.fillFraction;
        if(timer.loadNextQuestion){
            if(progressBar.value==progressBar.maxValue){
        isComplete= true;
        return;
    }
            hasAnsweredEarly=false;
            GetNextQuestion();
            timer.loadNextQuestion=false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion){
            DisplayAnswer(-1);
            SetButtonState(false);

        }
    }
    void DisplayAnswer(int index){
        if(index== currentQuestion.GetCorrectAnswerIndex()){
            questionText.text="Correct!";
            Image buttonImage =answerButtons[index].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
            scoreKeeper.IncrementCorrectanswers();
        }
        else{
            correctAnswerIndex=currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text=("Incorrect :( \n The Correct Answer is: " + correctAnswer);
            Image buttonImage =answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite=correctAnswerSprite;
        
        }
    }
   public void OnAnswerSelected(int index){
       
        hasAnsweredEarly=true;
        DisplayAnswer(index);
    SetButtonState(false);
    timer.CancelTimer();
    scoreText.text="Score: " + scoreKeeper.CalculateScore() + "%"; 
    

   }
   void DisplayQuestion(){
        questionText.text=currentQuestion.GetQuestion();
        for(int i = 0; i<answerButtons.Length; i++){
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text=currentQuestion.GetAnswer(i);
        }

   }

void GetNextQuestion(){
    if(questions.Count>0){
    SetButtonState(true);
    
    GetRandomQuestion();
    DisplayQuestion();
    SetDefaultButtonSprite();
    scoreKeeper.IncrementQuestionsSeen();
    progressBar.value++;
    }
}
void GetRandomQuestion(){
    int index = Random.Range(0,questions.Count);
    currentQuestion=questions[index];

    if(questions.Contains(currentQuestion)){
    questions.Remove(currentQuestion);
    }
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
            buttonImage.sprite=defaultAnswerSprite;
    }

}
}

