using UnityEngine;
using System.Collections;

public class ChunkBehaviour : MonoBehaviour {

    public Transform[] propTransforms;
    public GameObject[] props;

	// Use this for initialization
	void Start () {
        PropPlacement();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void PropPlacement()
    {
        float roll = Random.Range(0, 100);
        foreach (Transform pos in propTransforms)
        {
            roll = Random.Range(0, 100);

            if (roll >= 75f)
            {
                Vector3 newPos = new Vector3(pos.position.x, pos.position.y, pos.position.z);
                Instantiate(props[Random.Range(0, props.Length)], newPos, Quaternion.identity);
            }
            
        }

        // int numOfTransforms = propTransforms.Length;
        // for (int i = 0; i < numOfTransforms; i++)
        // {
        //     Instantiate(props[Random.Range(0, props.Length)], newChunk, Quaternion.identity);
        // }
    }
}
