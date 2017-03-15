using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //WLS is WinLoseScreen

    public Text titleWLS;

    public Text scoreText;
    public Text scoreTextWLS;
    public int score;
    public Text highscoreText;
    public Text hightscoreTextWLS;
    public Text timerText;
    public Text livesLeft;
    public float timer;
    private int multi;
    public GameObject player;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    void Start ()
    {
        timer = 0;
        InitializeScores();            
    }

	void Update ()
    {
        string multiplyer = " ";

        if(player.GetComponent<Health>().dying == false)
        timer += Time.deltaTime;

        if(timer < 80)
        {
            multiplyer = "    X4";
            multi = 4;
        }
        if (timer > 80 && timer < 120)
        {
            multiplyer = "    X2";
            multi = 2;
        }

        timerText.text = timer.ToString("N0") + multiplyer;
        //Display int to string
        scoreText.text = score.ToString();
        scoreTextWLS.text = score.ToString();


        //Save prefs
        //PlayerPrefs.Save();
    }

    void DidIWinOrLose(string title)
    {
        titleWLS.text = title;
    }

    void CalculateLives(int lives)
    {
        if (lives < 0)
            lives = 0;
        
        livesLeft.text = "Lives Remaining " + lives.ToString();
    }

    void CalculateFinalScore()
    {
        score *= multi;
        StoreHighscore(score);
    }

    void CalculateStarRating()
    {
        if (score < 2000)
        {
            star1.SetActive(true);
        }
        if (score >= 2000 && score < 10000)
        {
            star1.SetActive(true);
            star2.SetActive(true);
        }
        if (score >= 10000)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
    }

    void InitializeScores()
    {
        score = 0;

        //Check for file
        if (PlayerPrefs.HasKey("highScore"))
        {
            //Display current high score from prefs
            highscoreText.text = PlayerPrefs.GetInt("highScore").ToString();
            hightscoreTextWLS.text = PlayerPrefs.GetInt("highScore").ToString();
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
            hightscoreTextWLS = scoreText;
        }
    }
}
