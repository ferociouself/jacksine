using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleExpansion : MonoBehaviour {

    public float timepassed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timepassed += 0.01f;
        this.transform.localScale = new Vector3(1.0f + timepassed, 1.0f + timepassed, 1.0f + timepassed);
	}
}
