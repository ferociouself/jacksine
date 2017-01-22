using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public float transitionTime=3.0f;
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
				//Switch to first scene
				SceneManager.LoadScene(1);
            }
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
}
