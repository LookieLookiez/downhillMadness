using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public float angle;
    public float height;
    private float updatedHeight;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        updatedHeight = player.transform.position.y + height;
	}

    void LateUpdate()
    {


        transform.position = player.transform.position;
        transform.position -= Vector3.forward * angle;
        transform.position = new Vector3(transform.position.x, updatedHeight, transform.position.z);
        transform.LookAt(player.transform.position);

    }
}
