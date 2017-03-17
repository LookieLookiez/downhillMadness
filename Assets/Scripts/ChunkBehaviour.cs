using UnityEngine;
using System.Collections;

public class ChunkBehaviour : MonoBehaviour {

    public Transform[] propTransforms;
    public GameObject[] props;

    void Start()
    {
        Debug.Log("im still working");
        PropPlacement();
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
    }
}
