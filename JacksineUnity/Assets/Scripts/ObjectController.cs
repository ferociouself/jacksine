using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject CreateRipple(Vector2 point, bool isPushing)
    {
        int rand = Random.Range(0, 6);
        GameObject ripple = Resources.Load<GameObject>("Prefabs/Ripples/ripple 0");
        GameObject rippleObj1 = GameObject.Instantiate(ripple);
        if (isPushing)
        {
            rippleObj1.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().constant = 1.0f;
            //rippleObj1.gameObject.tag = "pushRipple";
        }
        else
        {
            rippleObj1.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().constant = -1.0f;
            //rippleObj1.gameObject.tag = "pullRipple";
        }
        rippleObj1.transform.position = point;
		return rippleObj1;
    }
}
