using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public GameObject winOrLose;
    public int health;
    public GameObject sESystem;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public bool dying;
    public AudioClip damage;

    void Start()
    {
        dying = false;
    }

    void Update()
    {
        if (health == 0 && !dying)
        {
            dying = true;
            Invoke("Death", 5);
            sESystem.GetComponent<SpeedEnergySystem>().dying = true;
        }
        if (health == 2)
            heart3.gameObject.SetActive(false);

        if (health == 1)
            heart2.gameObject.SetActive(false);

        if (health <= 0)
            heart1.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            GetComponent<AudioSource>().PlayOneShot(damage, 2);
            health -= 1;  
        }

        if(other.gameObject.CompareTag("KillZone"))
        {
            dying = true;
            Invoke("Death", .2f);
            sESystem.GetComponent<SpeedEnergySystem>().dying = true;
        }
    }

    void Death()
    {
        winOrLose.GetComponent<WinOrLose>().GameHasEnded("lose", health);
    }
}