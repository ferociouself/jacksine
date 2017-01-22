using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    public float scrollSpeed;
    float timeSpent;
    bool hasBeenStopped;
    int counter = 0;

	// Use this for initialization
	void Start () {
        Vector2 force = new Vector2(0f, scrollSpeed);
        GetComponent<Rigidbody2D>().AddForce(force);

    }

    // Update is called once per frame
    void Update ()
    {
        timeSpent += 1f;
        counter++;
        if (timeSpent > 523 && !hasBeenStopped)
        {
            Vector2 oppForce = new Vector2(0f, -scrollSpeed);
            GetComponent<Rigidbody2D>().AddForce(oppForce);
            hasBeenStopped = true;
            counter --;
        }
        if (counter <= 523)
            print(counter);
    }
}
