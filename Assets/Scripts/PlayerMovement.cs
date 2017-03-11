using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public GameObject cameraGO;
    public GameObject self;
    public GameObject endPoint;

    public float speed;
    public float jumpForce;
    private float constSpeed;
    private float rate;

    private float timer;

    private Rigidbody rb;

    void Start()
    {
        cameraGO = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
        timer = 0;

        constSpeed = 50;
    }

    void Update()
    {


        
        cameraGO.GetComponent<Camera>().fieldOfView = 60 + rb.velocity.z;





        Debug.Log(timer);
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown("space") && timer <= 0)
        {
            rb.AddForce(Vector3.up * jumpForce);
            Debug.Log("I jumped");
            timer = 3;

        }
    }

    void FixedUpdate()
    {

        var aimDir = endPoint.transform.position - self.transform.position;
        var dist = aimDir.magnitude;
        var dir = aimDir / dist;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        rb.AddForce(dir * constSpeed);

        
    }
}
