using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class RippleSpawner : MonoBehaviour {

	public bool useEyeTracking = true;
	public float time;
    ObjectController objCont;

	// Use this for initialization
	void Start () {
		time = 0;
		Debug.Log ("Time Scale: " + Time.timeScale);
        objCont = gameObject.GetComponent<ObjectController>();
		if (useEyeTracking) {
			EyeTracking.Initialize ();
		}
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown ("Shoot")) {
			Debug.Log ("Shooting!");
			Vector3 posVec;
			if (useEyeTracking) {
				GazePoint point = EyeTracking.GetGazePoint ();
				posVec = (Camera.main.ScreenToWorldPoint ((Vector3)point.Screen));
			} else {
				posVec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
			posVec.z = 0;
			GameObject ripple = objCont.CreateRipple ((Vector2)posVec);

			//scale ripple by time waited
			ripple.transform.GetChild (0).gameObject.GetComponent<Embiggener>().maxSize*=(time/5.0f);
			ripple.transform.GetChild (1).gameObject.GetComponent<Embiggener>().maxSize*=(time/5.0f);
			ripple.transform.GetChild (2).gameObject.GetComponent<Embiggener>().maxSize*=(time/5.0f);
			ripple.transform.GetChild (3).gameObject.GetComponent<Embiggener>().maxSize*=(time/5.0f);


			time=0; 


		} else {

			if(time<=5.0f){
			time+=Time.deltaTime;
			}
		}
	}
}