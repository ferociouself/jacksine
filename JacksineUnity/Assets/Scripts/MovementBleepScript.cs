using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBleepScript : MonoBehaviour {
	public float speedMultiplier;
	public float lowPitch;
	public float midPitch;
	public float hiPitch;
	public float lowThreshold;
	public float hiThreshold;
	public float cooldownThreshold;	// amount of time between audio play

    public float minSpeed;

	private Rigidbody2D body;
	private float pitch;
	private float cooldownTimer;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		pitch = this.GetComponent<AudioSource> ().pitch;
		cooldownTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float speed = body.velocity.magnitude*speedMultiplier;
		if (speed > minSpeed && cooldownTimer >= cooldownThreshold) {
			AudioSource audio = this.GetComponent < AudioSource> ();
			if (speed > hiThreshold) {
				audio.pitch = hiPitch;
			} else if (speed < lowThreshold) {
				audio.pitch = lowPitch;
			} else {
				audio.pitch = midPitch;
			}
			audio.Play ();
			cooldownTimer = 0.0f;
		}

		cooldownTimer += Time.deltaTime;
	}
}
