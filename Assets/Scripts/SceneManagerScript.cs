using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public Scene mainMenu;
    public Scene level1;
    public Scene level2;
    public Scene level3;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeScene(int WhichIdentifier)
    {
        // 0 = main menu
        // 1 = restart
        // 2 = next in line
        int chosenLoad = 0;
        
        if (WhichIdentifier == 0)
            chosenLoad = 0;

        if (WhichIdentifier == 1)
            chosenLoad = SceneManager.GetActiveScene().buildIndex;

        if (WhichIdentifier == 2)
            chosenLoad = SceneManager.GetActiveScene().buildIndex + 1;


        SceneManager.LoadScene(chosenLoad);
    }
}
