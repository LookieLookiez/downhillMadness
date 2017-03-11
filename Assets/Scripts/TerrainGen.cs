using UnityEngine;
using System.Collections;

public class TerrainGen : MonoBehaviour {

    public Transform terrainSlot;

    public GameObject[] chunks;
    

    private float lengthOffset;
    private float heightOffset;



    // Use this for initialization
    void Start () {
        lengthOffset = 0;
        heightOffset = 0;
        Build();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Build()
    {


        for (int i = 0; i < 20; i++)
        {
            Vector3 newChunk = new Vector3(terrainSlot.transform.position.x, terrainSlot.transform.position.y - heightOffset, terrainSlot.transform.position.z + lengthOffset);

            
                Instantiate(chunks[Random.Range(0, chunks.Length)], newChunk, terrainSlot.transform.rotation);
            
            lengthOffset += 172f;
            heightOffset += 24.18f;

        }
    }
}

