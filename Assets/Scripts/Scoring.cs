using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour
{

    public GameObject scoreManager;
    public GameObject wall;
    public AudioClip winTheme;
    public AudioClip collect;
    AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Points"))
        {
            scoreManager.SendMessage("RecieveScore", 20f);
            GetComponent<AudioSource>().PlayOneShot(collect, 1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().PlayOneShot(winTheme, 1);
            scoreManager.GetComponent<WinOrLose>().GameHasEnded("win", GetComponent<Health>().health);
            Destroy(other.gameObject);
        }
    }
}

