﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour {

    public float spinSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime * spinSpeed));
	}
}
