using UnityEngine;
using System.Collections;

public class WinOrLose : MonoBehaviour {

    public GameObject player;
    public GameObject winLoseScreen;
    public GameObject scoreManager;

    public void GameHasEnded(string WinLose, int health)
    {
        if(WinLose == "win")
        {
            scoreManager.SendMessage("DidIWinOrLose", "Winner");
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        if(WinLose == "lose")
        {
            scoreManager.SendMessage("DidIWinOrLose", "Loser");
            player.SetActive(false);
        }
        scoreManager.SendMessage("CalculateLives", health);
        scoreManager.SendMessage("CalculateFinalScore");
        scoreManager.SendMessage("CalculateStarRating");
        
        winLoseScreen.GetComponent<Animator>().SetBool("Finished", true);
    }
}
