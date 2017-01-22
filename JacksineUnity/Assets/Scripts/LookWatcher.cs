using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

[RequireComponent(typeof(GazeAware))]
public class LookWatcher : MonoBehaviour {

    GazeAware gaze;

    public GameObject mainMenuCont;

	// Use this for initialization
	void Start () {
        gaze = GetComponent<GazeAware>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gaze.HasGazeFocus)
        {
           mainMenuCont.GetComponent<MainMenuController>().BeginGame();
        }
	}
}
