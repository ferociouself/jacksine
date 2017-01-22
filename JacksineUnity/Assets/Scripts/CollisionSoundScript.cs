using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundScript : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Contains("ood")) {
			if (GetComponent<AudioSource>() != null && !GetComponent<AudioSource>().isPlaying)
            {
				if (coll.gameObject.GetComponent<AudioSource>() != null && !coll.gameObject.GetComponent<AudioSource>().isPlaying) {
	                int rand = Random.Range(1, 8);
	                this.gameObject.GetComponent<AudioSource>().clip = (AudioClip)(Resources.Load("Audio/2Hit" + rand + "Low", typeof(AudioClip)));
	                this.gameObject.GetComponent<AudioSource>().Play();
				}
            }
		}
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ripple")
        {
            
            AudioSource source = gameObject.GetComponent<AudioSource>();
            if (!source.isPlaying)
            {
                float timeLeft = coll.gameObject.GetComponent<RippleHitObject>().getTimeLeft();
                source.clip = (AudioClip)(Resources.Load("Audio/" + ((level == "Zen")?"2":level) + "Hit" + ((((int)(10 * timeLeft)) % 7) + 1), typeof(AudioClip)));
                source.Play();
            }
        }
    }
}
