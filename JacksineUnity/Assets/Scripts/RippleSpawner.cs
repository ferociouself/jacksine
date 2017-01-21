using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class RippleSpawner : MonoBehaviour {

	public bool useEyeTracking = true;
	private float time;
    ObjectController objCont;

	// Use this for initialization
	void Start () {
		time = 0;
        objCont = gameObject.GetComponent<ObjectController>();
		if (useEyeTracking) {
			EyeTracking.Initialize ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Shoot"))
        {
			Vector3 posVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (useEyeTracking) {
				GazePoint point = EyeTracking.GetGazePoint();
                if(point.Timestamp > Time.time - (10 * Time.deltaTime))
				    posVec = (Camera.main.ScreenToWorldPoint(point.Screen));
			}
			GameObject ripple = objCont.CreateRipple (posVec);

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