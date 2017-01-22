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

	public GameObject CreateRipple(Vector2 point, bool isPushing, float power)
    {
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

        rippleObj1.transform.GetChild(0).GetComponent<RippleHitObject>().power = power;
   
        Vector3 tranVec = new Vector3(point.x, point.y, 4);
        rippleObj1.transform.position = tranVec;

        AudioSource source = GetComponent<AudioSource>();
        if (source != null)
        {
            int rand = Random.Range(1, 5);
            source.clip = (AudioClip)(Resources.Load("Audio/Light" + rand, typeof(AudioClip)));
            source.Play();
        }

        return rippleObj1;
    }
}
