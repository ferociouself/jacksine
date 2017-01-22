using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandRippleDyingScript : MonoBehaviour {

    float timer = 0.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += 0.05f;
        if (timer > 1.0f)
        {
            GameObject.Destroy(this);
        }
	}
}
