using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

  [SerializeField] int scorePerHit = 20;
  [SerializeField] int scorePerSecond = 10;
  
  float time;
  float timeFromLastPoint = 0;
  int score;
  Text scoreText;

    void Start(){
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit(){
      score = score + scorePerHit;
      scoreText.text = score.ToString();
    }

    void Update(){
      ScoreSurvival();
    }

    public void ScoreSurvival(){
      time = Time.time;
      float timeDifference = time - timeFromLastPoint;
      if (timeDifference > 1){
        score = score + 5;
        scoreText.text = score.ToString();
        timeFromLastPoint = time;
      }
    }
}
