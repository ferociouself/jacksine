using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class PickupParticles : MonoBehaviour {

    ParticleSystem particles;

	// Use this for initialization
	void Start () {
        particles = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        particles.Emit(30);
    }
}
