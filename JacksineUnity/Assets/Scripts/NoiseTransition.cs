using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class NoiseTransition : MonoBehaviour {
	public float transitionTime;	// amount of time between screen transitions
	public float noiseIntensityMax;
	public int sceneDestinationId;

	private bool beginning = false;
	private float beginTimer = 0.0f;

	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		if (beginning)
		{
			beginTimer += Time.deltaTime;
			if (beginTimer > transitionTime)
			{
				// load different scene
				SceneManager.LoadScene (sceneDestinationId);
				beginning = false;
			}
			this.GetComponent<NoiseAndGrain> ().intensityMultiplier = Mathf.Lerp (0.0f, noiseIntensityMax, beginTimer / transitionTime);
		}
	}

	public void BeginTransition()
	{
		beginning = true;
	}
}
