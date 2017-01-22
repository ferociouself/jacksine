using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    bool beginning = false;

    float beginTimer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (beginning)
        {
            beginTimer += Time.deltaTime;
            Debug.Log(beginTimer);
            if (beginTimer > 2.0f)
            {
                SceneManager.LoadScene(1);
                //Switch to first scene
            }
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
