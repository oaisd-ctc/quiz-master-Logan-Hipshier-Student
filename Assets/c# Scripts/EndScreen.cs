using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
    }
    public void FinalScore(){
        finalScoreText.text = "Congratulations! \nYou got a score of " + scoreKeeper.CalculateScore() + "%";
    }

    
}
