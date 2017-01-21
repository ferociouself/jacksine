using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D (Collider2D other)
    {
        Destroy(other.gameObject);
        AudioSource source = GetComponent<AudioSource>();
        int rand = Random.Range(1, 4);
        source.clip = (AudioClip)(Resources.Load("Audio/Hole" + rand, typeof(AudioClip)));
        source.Play();
    }
}
