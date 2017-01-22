using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

[RequireComponent(typeof(GazeAware))]
public class LookWatcher : MonoBehaviour {

    GazeAware gaze;

	bool mousing = false;

	public string choice;

    public GameObject mainMenuCont;

	// Use this for initialization
	void Start () {
        gaze = GetComponent<GazeAware>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (choice) {
		case "Zen":
			mainMenuCont.GetComponent<MainMenuController>().zenMove = gaze.HasGazeFocus || mousing;
			break;
		case "Main":
			mainMenuCont.GetComponent<MainMenuController>().mainMove = gaze.HasGazeFocus || mousing;
			break;
		}
		if (gaze.HasGazeFocus && choice == "Begin")
        {
			gameObject.SetActive(false);
			mainMenuCont.GetComponent<MainMenuController>().BeginGame();
        }
	}

	void OnMouseEnter() { mousing = true; }

	void OnMouseExit() { mousing = false; }
}
