using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

    public GameObject scoreManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Points"))
        {
            scoreManager.SendMessage("RecieveScore", 20f);
            Destroy(other.gameObject);
        }
            
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            scoreManager.SendMessage("CalculateFinalScore");
        }
    }
}
