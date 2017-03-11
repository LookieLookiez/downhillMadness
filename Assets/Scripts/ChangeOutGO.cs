using UnityEngine;
using System.Collections;

public class ChangeOutGO : MonoBehaviour {

    public GameObject breakableGo;
    public GameObject player;

    public GameObject points;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
           

            Instantiate(breakableGo, transform.position, transform.rotation);
            
            if(this.gameObject.CompareTag("House"))
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector3 RandomPlacement = new Vector3(
                gameObject.transform.position.x + Random.Range(0, 10),
                gameObject.transform.position.y + Random.Range(0, 10),
                gameObject.transform.position.z + Random.Range(0, 10));
                    Instantiate(points, RandomPlacement, transform.rotation);
                }
                
                
            }
            if (this.gameObject.CompareTag("Fence"))
            {
               
                    Vector3 RandomPlacement = new Vector3(
                gameObject.transform.position.x + Random.Range(0, 10),
                gameObject.transform.position.y + Random.Range(0, 10),
                gameObject.transform.position.z + Random.Range(0, 10));
                    Instantiate(points, RandomPlacement, transform.rotation);
                
            }
            if (this.gameObject.CompareTag("Tree"))
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector3 RandomPlacement = new Vector3(
                gameObject.transform.position.x + Random.Range(0, 10),
                gameObject.transform.position.y + Random.Range(0, 10),
                gameObject.transform.position.z + Random.Range(0, 10));
                    Instantiate(points, RandomPlacement, transform.rotation);
                }
            }

            Destroy(gameObject);



        }
    }

}
