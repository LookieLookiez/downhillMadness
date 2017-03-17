using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public GameObject cameraGO;
    public GameObject self;
    public GameObject endPoint;
    public GameObject kickUp;
    public float speed;
    public float jumpForce;
    private float constSpeed;
    private float rate;
    private float timer;
    private Rigidbody rb;
    public bool playingAudio;
    public bool playingSoar;
    public bool isGrounded;
    public AudioClip soar;
    public AudioClip impact;
    public GameObject soaring;



    void Start()
    {
        cameraGO = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
        timer = 0;
        constSpeed = 50;

        Instantiate(kickUp, self.transform.position, Quaternion.identity);

        kickUp = GameObject.FindGameObjectWithTag("KickUp");
    }

    void Update()
    {
        cameraGO.GetComponent<Camera>().fieldOfView = 60 + rb.velocity.z;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown("space") && timer <= 0)
        {
            rb.AddForce(Vector3.up * jumpForce);
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

        RaycastHit hit;

        if (Physics.Raycast(self.transform.position, -Vector3.up, out hit))
        {
            Debug.Log(hit.collider.name);

            if (hit.distance < 4)
            {
                isGrounded = true;
                playingSoar = false;
                soaring.GetComponent<AudioSource>().Stop();
                if (hit.collider.CompareTag("Ground"))
                {
                    kickUp.transform.position = hit.point;
                    kickUp.GetComponent<ParticleSystem>().Play();
                    
                    if(!playingAudio)
                    {
                        GetComponent<AudioSource>().Play();
                        
                        playingAudio = true;
                    }

                }
                else
                {
                    kickUp.GetComponent<ParticleSystem>().Stop();
                }
            }
            else
            {
                
                isGrounded = false;
                GetComponent<AudioSource>().Stop();
                playingAudio = false;
                if(!playingSoar)
                {
                    soaring.GetComponent<AudioSource>().Play();
                    playingSoar = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            GetComponent<AudioSource>().PlayOneShot(impact, .2f);
        }
    }
}
    

