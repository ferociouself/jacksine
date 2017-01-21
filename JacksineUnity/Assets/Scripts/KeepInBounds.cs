using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInBounds : MonoBehaviour {

    public float force = 1.0f;

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
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        }
        if (pos.x >= topRight.x)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        }
        if (pos.y < botLeft.y)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }
        if (pos.y >= topRight.y)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * force);
        }
	}
}
