using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText = null;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
    
    public void IncreaseScore(int value)
    {
        score += value;
       scoreText.text = "Score: " + score;
    }
    
    public void ScoreReset()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
