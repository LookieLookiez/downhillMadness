using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public int score;
    public Text highscoreText;
    public Text timerText;
    public float timer;
    private int multi;

    void Start ()
    {
        timer = 0;
        InitializeScores();            
    }

	void Update ()
    {
        string multiplyer = " ";
        timer += Time.deltaTime;

        if(timer < 60)
        {
            multiplyer = "    X4";
            multi = 4;
        }
        if (timer > 60 && timer < 120)
        {
            multiplyer = "    X2";
            multi = 2;
        }

        timerText.text = timer.ToString("N0") + multiplyer;
        //Display int to string
        scoreText.text = score.ToString();

        //Save prefs
        //PlayerPrefs.Save();
    }

    void CalculateFinalScore()
    {
        score *= multi;
        StoreHighscore(score);
    }

    void InitializeScores()
    {
        score = 0;

        //Check for file
        if (PlayerPrefs.HasKey("highScore"))
        {
            //Display current high score from prefs
            highscoreText.text = PlayerPrefs.GetInt("highScore").ToString();
        }
        else
        {
            highscoreText.text = score.ToString();
        }
    }

    void RecieveScore(int scoreIn)
    {
        score += scoreIn;
    }

    void StoreHighscore(int newHighscore)
    {
        //If the new score is higher than previous save it out
        if (newHighscore > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", newHighscore);
            highscoreText = scoreText;
        }
    }
}
