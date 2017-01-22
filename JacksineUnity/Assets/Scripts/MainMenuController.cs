using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public float transitionTime=3.0f;
    private bool beginning = false;
    private float beginTimer = 0.0f;

	bool starting = false;

	public GameObject logo;
	public GameObject beginText;
	public GameObject vectorField;

	public GameObject ZenSelect;
	public GameObject MainSelect;
	public GameObject instButton;
	public GameObject startButton;

	public GameObject ZenGaze;
	public GameObject MainGaze;

    public GameObject Instructions;

	bool menuActive = false;

	bool begun = false;

	public bool zenMove = false;
	public bool mainMove = false;

	float curZenX = 0.0f;
	float curMainX = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (beginning && !begun) {
			TurnOffLogo();
		}
		if (Input.GetButtonDown ("Shoot") && !beginning) {
			BeginGame ();
		}
		if (pos_Lerping) {
			PosTimedLerp();
		}


		if (zenMove) {
			MoveZen(-1);
		} else if (ZenSelect.GetComponent<RectTransform>().anchoredPosition.x < 15.3) {
			MoveZen(1);
		}
		if (ZenSelect.GetComponent<RectTransform>().anchoredPosition.x < -500 && !starting) {
			StartZen();
			starting = true;
		}

		if (mainMove) {
			MoveMain(1);
		} else if (MainSelect.GetComponent<RectTransform>().anchoredPosition.x > -15.3) {
			MoveMain(-1);
		}
		if (MainSelect.GetComponent<RectTransform>().anchoredPosition.x > 500 && !starting) {
			StartMain();
			starting = true;
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

			vectorField.GetComponent<VectorField>().forceMultiplier = 100.0f;
        }
    }

	void StartZen() {
		Camera.main.GetComponent<NoiseTransition>().sceneDestinationId = 4;
		Camera.main.GetComponent<NoiseTransition>().BeginTransition();
	}

	void StartMain() {
		Camera.main.GetComponent<NoiseTransition>().sceneDestinationId = 1;
		Camera.main.GetComponent<NoiseTransition>().BeginTransition();
	}

	public void TurnOffLogo() {
		if (ColTimedLerp()) {
			menuActive = true;
			//Turn on new buttons
			Instructions.SetActive(true);
			startButton.SetActive(true);

			initZenPos = ZenSelect.GetComponent<RectTransform>().anchoredPosition;
			initMainPos = MainSelect.GetComponent<RectTransform>().anchoredPosition;
			finalZenPos = new Vector2(12.8f, 0.0f);
			finalMainPos = new Vector2(-12.8f, 0.0f);
			curZenX = 12.8f;
			curMainX = -12.8f;
			pos_Lerping = true;


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

	bool pos_Lerping = false;
	public const float POS_LERP_TIME = 2.0f;
	float pos_transTime = 0.0f;

	Vector2 initZenPos;
	Vector2 finalZenPos;

	Vector2 initMainPos;
	Vector2 finalMainPos;


	public bool PosTimedLerp() {

		float timerVal = pos_transTime / POS_LERP_TIME;

		ZenSelect.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(initZenPos, finalZenPos, timerVal);
		MainSelect.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(initMainPos, finalZenPos, timerVal);

		if (pos_transTime > POS_LERP_TIME) {
			pos_transTime = 0.0f;
			pos_Lerping = false;
            ZenGaze.SetActive(true);
            MainGaze.SetActive(true);
            return true;
        }  else {
			pos_transTime += Time.deltaTime;
			return false;
		}
	}

	public void MoveZen(int dir) {
		curZenX += dir * 5.0f;
		ZenSelect.GetComponent<RectTransform>().anchoredPosition = new Vector2(curZenX, 0.0f);
	}

	public void MoveMain(int dir) {
		curMainX += dir * 5.0f;
		MainSelect.GetComponent<RectTransform>().anchoredPosition = new Vector2(curMainX, 0.0f);
	}

    public void Quit()
    {
        Application.Quit();
    }

}
