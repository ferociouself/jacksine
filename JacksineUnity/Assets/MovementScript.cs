using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		Vector2 v = new Vector2 ();
		v.x = 0;
		v.y = -1;
		this.gameObject.GetComponent<Rigidbody2D> ().AddForce ( v, ForceMode2D.Force);
	}
}
