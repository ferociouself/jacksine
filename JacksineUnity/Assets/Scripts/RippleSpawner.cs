using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class RippleSpawner : MonoBehaviour {

	public bool useEyeTracking = true;
	public bool isPushing;
	public float minPower;
	public float maxPower;
	public float minRippleMultiplier;
	public float maxRippleMultiplier;
	public float timeToMaxPower;

	private float chargeTime;
	private bool isCharging;
	private Vector3 posVec;
    ObjectController objCont;

	// Use this for initialization
	void Start () {
        objCont = gameObject.GetComponent<ObjectController>();
		chargeTime = 0f;
		isCharging = false;
		posVec = Vector3.zero;
		if (useEyeTracking) {
			EyeTracking.Initialize ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isCharging) {
			chargeTime += Time.deltaTime;
		}
		if (Input.GetButtonDown ("Shoot")) {
			posVec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (useEyeTracking) {
				GazePoint point = EyeTracking.GetGazePoint ();
				if (point.Timestamp > Time.time - (10 * Time.deltaTime))
					posVec = (Camera.main.ScreenToWorldPoint (point.Screen));
			}
			posVec.z = 0f;
			isCharging = true;
			chargeTime = 0f;
		}
		if (Input.GetButtonUp ("Shoot")) {
			float t = Mathf.Max (0f, Mathf.Min (1f, chargeTime / timeToMaxPower));
			float power = Mathf.Lerp (minPower, maxPower, t);
			float rippleMultiplier = Mathf.Lerp (minRippleMultiplier, maxRippleMultiplier, t);
			GameObject ripple = objCont.CreateRipple ((Vector2)posVec, isPushing, power);

			//scale ripple by time waited
			for (int x = 0; x < 4; x++) {
				ripple.transform.GetChild (x).gameObject.GetComponent<Embiggener> ().maxSize *= rippleMultiplier;
			}
			isCharging = false;
		}
	}
}