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
        int rand = Random.Range(0, 6);
        GameObject ripple = (GameObject)(Resources.Load("Prefabs/Ripples/ripple 0", typeof(GameObject)));
        GameObject rippleObj1 = GameObject.Instantiate(ripple);

        Vector3 tranVec = (Vector3)point;

        rippleObj1.transform.position = tranVec;
    }
}
