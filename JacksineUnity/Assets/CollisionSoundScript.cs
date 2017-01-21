using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Food")
			this.gameObject.GetComponent<AudioSource> ().Play ();
	}
}
