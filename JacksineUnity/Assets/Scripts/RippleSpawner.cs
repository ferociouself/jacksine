﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class RippleSpawner : MonoBehaviour {

	public bool useEyeTracking = true;
    ObjectController objCont;

	// Use this for initialization
	void Start () {
        objCont = gameObject.GetComponent<ObjectController>();
		if (useEyeTracking) {
			EyeTracking.Initialize ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Shoot"))
        {
            Debug.Log("Shooting!");
			Vector3 posVec;
			if (useEyeTracking) {
				GazePoint point = EyeTracking.GetGazePoint ();
				posVec = (Camera.main.ScreenToWorldPoint ((Vector3)point.Screen));
			} else {
				posVec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
            posVec.z = 0;
            objCont.CreateRipple((Vector2)posVec);
        }
	}
}
