using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RemoveObject : MonoBehaviour {

    public int score = 0;
    public Text text;
    public bool isEvil;

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
            if (!isEvil)
            {
                GameObject.Find("GLaDOS").GetComponent<GLaDOS>().FoodInHoleChange(1);
                score += 1;
            }
            else
            {
                score -= 1;
            }
        }
        else if (other.tag.Contains("bad"))
        {
            if (isEvil)
            {
                GameObject.Find("GLaDOS").GetComponent<GLaDOS>().FoodInHoleChange(1);
                score += 1;
            }
            else
            {
                score -= 1;
            }
        }
        //Destroy(other.gameObject);
        AudioSource source = GetComponent<AudioSource>();
        if (!source.isPlaying)
        {
            int rand = Random.Range(1, 4);
            source.clip = (AudioClip)(Resources.Load("Audio/Hole" + rand, typeof(AudioClip)));
            source.Play();
        }
        string textToAdd = "Score: " + score;
        //text = GetComponent<Text>();
        if (text != null)
        {
            text.text = textToAdd;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Contains("good"))
        {
            if (!isEvil)
            {
                GameObject.Find("GLaDOS").GetComponent<GLaDOS>().FoodInHoleChange(-1);
                score -= 1;
            }
        }
        else if (other.tag.Contains("bad"))
        {
            if (isEvil)
            {
                GameObject.Find("GLaDOS").GetComponent<GLaDOS>().FoodInHoleChange(-1);
                score -= 1;
            }
        }
    }
}
