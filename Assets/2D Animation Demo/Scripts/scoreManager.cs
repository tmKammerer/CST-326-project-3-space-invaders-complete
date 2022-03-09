using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    private int lengthScore = 4;
    public int highScore=0;
    public int score=0;

    public string hiScore;
    public string scores;

    public Text scoreBoard;
    public Text highScoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        
        if (score <= 9)
        {
            scores = "000" + score.ToString();
        }
        else if (score >= 10 && score <= 99)
        {
            scores = "00" + score.ToString();
        }
        else if (score >= 100 && score <= 999)
        {
            scores = "0" + score.ToString();
        }
        else
        {
            scores = score.ToString();
        }
        
        scoreBoard.text = scores;
        if (highScore <= 9)
        {
            highScoreBoard.text = "000" + PlayerPrefs.GetInt("score").ToString();
        }
        else if (highScore >= 10 && highScore <= 99)
        {
            highScoreBoard.text = "00" + PlayerPrefs.GetInt("score").ToString();
        }
        else if (highScore >= 100 && highScore <= 999)
        {
            highScoreBoard.text = "0" + PlayerPrefs.GetInt("score").ToString();
        }
        else
        {
            highScoreBoard.text = PlayerPrefs.GetInt("score").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoints(int points)
    {
        score += points;

        highScore = (int)score;

        if (score <= 9)
        {
            scores = "000" + score.ToString();
        }
        else if (score >= 10 && score <= 99)
        {
            scores = "00" + score.ToString();
        }
        else if (score >= 100 && score <= 999)
        {
            scores = "0" + score.ToString();
        }
        else
        {
            scores = score.ToString();
        }
        
        scoreBoard.text = scores;

        if (PlayerPrefs.GetInt("score") <= highScore)
        {
            PlayerPrefs.SetInt("score", highScore);
            

            if (highScore <= 9)
            {
                highScoreBoard.text ="000"+PlayerPrefs.GetInt("score").ToString();
            }
            else if (highScore >= 10 && highScore <= 99)
            {
                highScoreBoard.text = "00" + PlayerPrefs.GetInt("score").ToString();
            }
            else if (highScore >= 100 && highScore <= 999)
            {
                highScoreBoard.text = "0" + PlayerPrefs.GetInt("score").ToString();
            }
            else
            {
                highScoreBoard.text = PlayerPrefs.GetInt("score").ToString();
            }

            

        }
    }


}
