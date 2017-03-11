using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {
    public GameObject player;

    public float speed;
    public Vector3 playerLoc;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 20;
	}
	
	// Update is called once per frame
	void Update () {
        speed += Time.deltaTime * 50;
        playerLoc = player.transform.position;


        var heading = player.transform.position - this.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        transform.Translate(direction * Time.deltaTime * speed);
	}
}
