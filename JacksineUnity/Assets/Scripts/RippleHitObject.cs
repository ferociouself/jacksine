using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleHitObject : MonoBehaviour {

    public float timepassed;
    public float timeleft;
    public float power;

	// Use this for initialization
	void Start () {
	}

    public void OnTriggerStay2D(Collider2D blob)
    {
        if (blob.tag == "Food")
        {
            blob.GetComponent<Rigidbody2D>().AddForce(timeleft * (blob.GetComponent<Rigidbody2D>().transform.position - transform.position) * power);
        }
    }

    // Update is called once per frame
    void Update () {
        timepassed += 0.01f;
        timeleft = 2.0f - timepassed;
        if (timeleft < 0.0f)
        {
            timeleft = 0.0f;
            print("timepassed is done");
        }
	}

    public float getTimeLeft()
    {
        return timeleft;
    }
}
