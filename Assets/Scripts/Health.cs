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

    // Use this for initialization
    void Start()
    {
        dying = false;
    }

    // Update is called once per frame
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
            health -= 1;  
        }
    }

    void Death()
    {
        winOrLose.GetComponent<WinOrLose>().GameHasEnded("lose", health);
    }
}