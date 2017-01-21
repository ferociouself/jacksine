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

    public void CreateRipple(Vector2 point)
    {
        GameObject ripple = (GameObject)(Resources.Load("Prefabs/Ripples/ripple 0", typeof(GameObject)));
        GameObject rippleObj1 = GameObject.Instantiate(ripple);

        Vector3 tranVec = (Vector3)point;

        rippleObj1.transform.position = tranVec;

        AudioSource source = GetComponent<AudioSource>();
        int rand = Random.Range(1, 5);
        source.clip = (AudioClip)(Resources.Load("Audio/Light" + rand, typeof(AudioClip)));
        source.Play();
    }
}
