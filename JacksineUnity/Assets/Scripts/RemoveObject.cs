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
                score += 1;
                print("Nom! Thanks for feeding the good food to the good whirlpool!");
            }
            else
            {
                score -= 1;
                print("Aww. You fed the good whirlpool bad food!");
            }
        }
        else if (other.tag.Contains("bad"))
        {
            if (isEvil)
            {
                score += 1;
                print("Great! You fed the bad food to the bad whirlpool!");
            }
            else
            {
                score -= 1;
                print("Too bad! You fed the bad whirlpool good food!");
            }
        }
        Destroy(other.gameObject);
        //AudioSource source = GetComponent<AudioSource>();
        //int rand = Random.Range(1, 4);
        //source.clip = (AudioClip)(Resources.Load("Audio/Hole" + rand, typeof(AudioClip)));
        //source.Play();
        string textToAdd = "Score: " + score;
        //text = GetComponent<Text>();
        if (text != null)
        {
            text.text = textToAdd;
        }
    }
}
