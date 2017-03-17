using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    public GameObject pauseScreen;
    public Vector3 originalPos;


	// Use this for initialization
	void Start () {
        originalPos = pauseScreen.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.GetComponent<Animator>().SetBool("Finished", true);
            
        }
	
	}

    public void UnPause()
    {
        pauseScreen.GetComponent<Animator>().SetBool("Finished", false);
        pauseScreen.transform.position = originalPos;
    }

    
}
