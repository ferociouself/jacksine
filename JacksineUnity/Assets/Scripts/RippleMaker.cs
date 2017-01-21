using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleMaker : MonoBehaviour {
    public Transform ripple;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Instantiate(ripple, Input.mousePosition, Quaternion.identity);
        }
	}

}
