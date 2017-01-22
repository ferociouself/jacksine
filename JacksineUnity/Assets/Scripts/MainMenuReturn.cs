using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuReturn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Exit"))
        {
            Camera.main.GetComponent<NoiseTransition>().sceneDestinationId = 0;
            Camera.main.GetComponent<NoiseTransition>().BeginTransition();
        }
	}
}
