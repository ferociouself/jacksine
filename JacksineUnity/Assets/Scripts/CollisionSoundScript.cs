using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Food")
			this.gameObject.GetComponent<AudioSource> ().Play ();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ripple")
        {
            
            AudioSource source = gameObject.GetComponent<AudioSource>();
            if (!source.isPlaying)
            {
                float timeLeft = coll.gameObject.GetComponent<RippleHitObject>().getTimeLeft();
                int rand = Random.Range(1, 8);
                source.clip = (AudioClip)(Resources.Load("Audio/Hit" + ((((int)(10 * timeLeft)) % 7) + 1), typeof(AudioClip)));
                //source.clip = (AudioClip)(Resources.Load("Audio/Hit" + rand, typeof(AudioClip)));
                source.Play();
            }
        }
    }
}
