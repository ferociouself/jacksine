using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBleepScript : MonoBehaviour {
	public float speedMultiplier;
	private Rigidbody2D body;
	private float pitch;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		pitch = this.GetComponent<AudioSource> ().pitch;
	}
	
	// Update is called once per frame
	void Update () {
		float speed = body.velocity.magnitude*speedMultiplier;
		if (speed > 0.001) {
			AudioSource audio = this.GetComponent < AudioSource> ();
			if (speed > 8) {
				audio.pitch = 3;
			} else if (speed < 1.1f) {
				audio.pitch = 0.2f;
			} else {
				audio.pitch = 3 - (3 / speed);
			}
			audio.Play ();
		}
	}
}
