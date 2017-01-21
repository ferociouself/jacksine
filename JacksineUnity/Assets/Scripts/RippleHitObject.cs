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

    public void OnTriggerEnter2D(Collider2D blob)
    {
        blob.GetComponent<Rigidbody2D>().AddForce(timeleft * Vector2.right * (blob.GetComponent<Rigidbody2D>().transform.position.x - this.transform.position.x) * power);
        blob.GetComponent<Rigidbody2D>().AddForce(timeleft * Vector2.up * (blob.GetComponent<Rigidbody2D>().transform.position.y - this.transform.position.y) * power);
    }

    public void OnTriggerStay2D(Collider2D blob)
    {
        blob.GetComponent<Rigidbody2D>().AddForce(timeleft * Vector2.right * (blob.GetComponent<Rigidbody2D>().transform.position.x - this.transform.position.x) * power);
        blob.GetComponent<Rigidbody2D>().AddForce(timeleft * Vector2.up * (blob.GetComponent<Rigidbody2D>().transform.position.y - this.transform.position.y) * power);
    }

    // Update is called once per frame
    void Update () {
        timepassed += Time.deltaTime;
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
