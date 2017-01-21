using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RemoveObject : MonoBehaviour {

    public int score = 0;
    public Text text;
    public bool isEvil;
    public int scoreModifier = 0;

	// Use this for initialization
	void Start () {
		if (isEvil)
        {
            scoreModifier = -1;
        }
        else
        {
            scoreModifier = 1;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag.Contains("good"))
        {
            score += (1 * scoreModifier);
        }
        else if (other.tag.Contains("bad"))
        {
            score += (-1 * scoreModifier); 
        }
        Destroy(other.gameObject);
        string textToAdd = "Score: " + score;
        //text = GetComponent<Text>();
        if (text != null)
        {
            text.text = textToAdd;
        }
    }
}
