using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RemoveObject : MonoBehaviour {

    public int score = 0;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag.Contains("good"))
        {
            score++;
        }
        else if (other.tag.Contains("bad"))
        {
            score--;
        }
        Destroy(other.gameObject);
        AudioSource source = GetComponent<AudioSource>();
        int rand = Random.Range(1, 4);
        source.clip = (AudioClip)(Resources.Load("Audio/Hole" + rand, typeof(AudioClip)));
        source.Play();
        string textToAdd = "Score: " + score;
        //text = GetComponent<Text>();
        text.text = textToAdd;
    }
}
