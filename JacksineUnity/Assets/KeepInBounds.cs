using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInBounds : MonoBehaviour {

    public static float FORCE = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.position;
        Vector2 botLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (pos.x < botLeft.x)
        {
            print("out left");
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * FORCE);
        }
        if (pos.x >= topRight.x)
        {
            print("out right");
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * FORCE);
        }
        if (pos.y < botLeft.y)
        {
            print("out bottom");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * FORCE);
        }
        if (pos.y >= topRight.y)
        {
            print("out top");
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * FORCE);
        }
	}
}
