﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject CreateRipple(Vector2 point)
    {
        GameObject ripple = Resources.Load<GameObject>("Prefabs/Ripples/ripple 0");
        GameObject rippleObj1 = Instantiate(ripple);

        Vector3 tranVec = new Vector3(point.x, point.y, 4);
        rippleObj1.transform.position = tranVec;

        AudioSource source = GetComponent<AudioSource>();
        int rand = Random.Range(1, 5);
        source.clip = (AudioClip)(Resources.Load("Audio/Light" + rand, typeof(AudioClip)));
        source.Play();
	return rippleObj1;
    }
}
