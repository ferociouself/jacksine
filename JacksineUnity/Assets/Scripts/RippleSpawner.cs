using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class RippleSpawner : MonoBehaviour {

    ObjectController objCont;

	// Use this for initialization
	void Start () {
        objCont = gameObject.GetComponent<ObjectController>();
        EyeTracking.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Shoot"))
        {
            Debug.Log("Shooting!");
            GazePoint point = EyeTracking.GetGazePoint();
            Vector3 posVec = (Camera.main.ScreenToWorldPoint((Vector3)point.Screen));
            posVec.z = 0;
            objCont.CreateRipple((Vector2)posVec);
        }
	}
}
