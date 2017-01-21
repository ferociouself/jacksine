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

    public void CreateRipple(Vector2 point)
    {
        GameObject ripple = (GameObject)(Resources.Load("Prefabs/Ripple", typeof(GameObject)));
        GameObject rippleObj1 = GameObject.Instantiate(ripple);

        Vector3 tranVec = (Vector3)point;

        rippleObj1.transform.position = tranVec;
    }
}
