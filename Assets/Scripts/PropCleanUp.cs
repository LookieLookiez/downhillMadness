﻿using UnityEngine;
using System.Collections;

public class PropCleanUp : MonoBehaviour {
    public GameObject self;

    // Use this for initialization
    void Start () {
        self = this.gameObject;
        Invoke("Destroy", 5);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void Destroy()
    {
        Destroy(self);
    }
}