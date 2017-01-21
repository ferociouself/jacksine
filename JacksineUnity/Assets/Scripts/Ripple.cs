using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour {
    public float BASERADIUS;
    public float SPEED = 1.0f;

    private float radius = 0;
    //private Transform[] circles;

	// Use this for initialization
	void Start () {
        //circles = transform.GetComponentsInChildren<Transform>();
        transform.localScale = new Vector3(0, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
		radius += SPEED * Time.deltaTime;
        transform.localScale = new Vector3(radius, radius, 1) / BASERADIUS;
	}
}
