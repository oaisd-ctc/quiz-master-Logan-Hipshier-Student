using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int questionsSeen=0;
   int correctAnswers=0;
   
   public int GetCorrectAnswers(){
    return(correctAnswers);
   }
   public void IncrementCorrectanswers(){
    correctAnswers++;
    Debug.Log(correctAnswers + "c");
   }
   public int GetQuestionsSeen(){
    return(questionsSeen);
   }
   public void IncrementQuestionsSeen(){
    questionsSeen++;
    Debug.Log(questionsSeen + "q");
   }
   public int CalculateScore(){
    Debug.Log(Mathf.RoundToInt(correctAnswers/questionsSeen *100));
    return (Mathf.RoundToInt(correctAnswers/(float)questionsSeen *100));
    
   }
}
