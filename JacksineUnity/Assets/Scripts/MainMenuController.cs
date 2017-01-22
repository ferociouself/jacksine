using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public float transitionTime=3.0f;
    private bool beginning = false;
    private float beginTimer = 0.0f;

	public GameObject logo;
	public GameObject beginText;

	bool menuActive = false;

	bool begun = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (begun)
        {
            beginTimer += Time.deltaTime;
			if (beginTimer > transitionTime)
            {
				//Switch to first scene
				SceneManager.LoadScene(1);
            }
        }
		if (beginning && !begun) {
			TurnOffLogo();
		}
		if (Input.GetButtonDown ("Shoot") && !beginning) {
			BeginGame ();
		}
	}

    public void BeginGame()
    {
        if (!beginning)
        {
            beginning = true;

            GameObject ripple = (GameObject)(Resources.Load("Prefabs/Ripples/ripple 0", typeof(GameObject)));
            GameObject rippleObj = GameObject.Instantiate(ripple);

            rippleObj.transform.localScale *= 3.0f;
            rippleObj.transform.position = new Vector3(0.0f, -3.85f, 0.0f);


        }
    }

	public void TurnOffLogo() {
		if (ColTimedLerp()) {
			menuActive = true;
			//Turn on new buttons
			begun = true;
		}
	}

	bool lerping = false;
	public const float LERP_TIME = 1.25f;
	float transTime = 0.0f;

	public bool ColTimedLerp() {

		float timerVal = transTime / LERP_TIME;

		logo.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1 - timerVal);
		beginText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1 - timerVal);

		if (transTime > LERP_TIME) {
			logo.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			beginText.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			transTime = 0.0f;
			lerping = false;
			return true;
		}  else {
			transTime += Time.deltaTime;
			return false;
		}
	}



}
