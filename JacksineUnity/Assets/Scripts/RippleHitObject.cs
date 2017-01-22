using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleHitObject : MonoBehaviour {

    public float timepassed;
    public float timeleft;
    public float power;
    public float constant;

	// Use this for initialization
	void Start ()
    {
        //if (this.tag == "pushRipple")
        //{
        //    constant = 1.0f;
        //}
        //else if (this.tag == "pullRipple")
        //{
        //    constant = -1.0f;
        //}
	}

    public void OnTriggerStay2D(Collider2D blob)
    {
        if (blob.tag == "Food" || blob.tag == "goodFood" || blob.tag == "badFood")
        {
            blob.GetComponent<Rigidbody2D>().AddForce(constant * timeleft * (blob.GetComponent<Rigidbody2D>().transform.position - transform.position) * power);
        }
    }

    // Update is called once per frame
    void Update () {
        timepassed += Time.deltaTime;
        timeleft = 5.0f - timepassed;
        if (timeleft < 0.0f)
        {
            timeleft = 0.0f;
            //print("timepassed is done");
        }
	}

    public float getTimeLeft()
    {
        return timeleft;
    }
}
