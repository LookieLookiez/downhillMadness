using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {
    private float speed = 5;

	void Update () {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
	}
}
