using UnityEngine;
using System.Collections;

public class WinOrLose : MonoBehaviour {

    public GameObject player;
    public GameObject winLoseScreen;
    public GameObject scoreManager;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GameHasEnded(string WinLose, int health)
    {
        if(WinLose == "win")
        {
            scoreManager.SendMessage("DidIWinOrLose", "Winner");
        }

        if(WinLose == "lose")
        {
            scoreManager.SendMessage("DidIWinOrLose", "Loser");
        }

        scoreManager.SendMessage("CalculateLives", health);
        scoreManager.SendMessage("CalculateFinalScore");
        scoreManager.SendMessage("CalculateStarRating");
        player.SetActive(false);
        //Time.timeScale = 0;
        winLoseScreen.GetComponent<Animator>().SetBool("Finished", true);
    }
}
