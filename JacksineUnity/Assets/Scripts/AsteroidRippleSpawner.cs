﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRippleSpawner : MonoBehaviour {
    Vector2 position;
    Quaternion rotation;
    public GameObject ripple;
    float cooldown;
    public float delay;
    float timespent = 0.00f;
    bool hasStarted = false;
    public float accelX;
    public float accelY;


    // Use this for initialization
    void Start ()
    {
        position = new Vector2(this.transform.position.x, this.transform.position.y);
        rotation = new Quaternion(0, 0, 0, 0);
        cooldown = 0f;
        ripple.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        ripple.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().constant = -1.0f;
        ripple.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().power = 0.01f;
        ripple.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().timeleft = 0.5f;
        
        
    }
	
    void startMove()
    {
        if (delay < timespent && !hasStarted)
        {
            Vector2 dir = new Vector2(accelX, accelY);
            this.GetComponent<Rigidbody2D>().AddForce(dir);
            hasStarted = true;
        }
    }

    void spawn()
    {
        Vector2 loc = new Vector2(this.transform.position.x, this.transform.position.y);
        position = loc;
        GameObject.Instantiate(ripple, position, rotation);
        cooldown = 0.14f;
    }

	// Update is called once per frame
	void Update () {
        timespent += 0.01f;
        startMove();
        if (cooldown > 0)
        {
            cooldown -= .02f;
        }
        else
        {
            if (this.transform.position.x < 2 && this.transform.position.y < 5)
            {
                if (hasStarted)
                { 
                    spawn();
                    //print("spawn was run");
                }
            }
        }
    }
}
