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
        GameObject rippleObj2 = GameObject.Instantiate(ripple);

        tranVec.z = -2;
        rippleObj2.transform.position = tranVec;
        rippleObj2.transform.localScale = 0.75f * rippleObj2.transform.localScale;
        rippleObj2.GetComponent<Embiggener>().sinOffset = 0.5f;
        GameObject rippleObj3 = GameObject.Instantiate(ripple);

        tranVec.z = -5;
        rippleObj3.transform.position = tranVec;
        rippleObj3.transform.localScale = 0.5f * rippleObj3.transform.localScale;
        rippleObj3.GetComponent<Embiggener>().sinOffset = 1.5f;
    }
}
