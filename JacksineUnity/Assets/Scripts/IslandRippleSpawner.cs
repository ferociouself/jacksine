using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandRippleSpawner : MonoBehaviour {
    Vector2 position;
    Quaternion rotation;
    public GameObject ripple;
    float cooldown;
    //public GameObject parent;

    // Use this for initialization
    void Start () {
        position = new Vector2(this.transform.position.x, this.transform.position.y);
        rotation = new Quaternion(0, 0, 0, 0);
        cooldown = 0f;
        ripple.transform.localScale = new Vector3(.025f, .025f, .025f);
        ripple.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().constant = 1.0f;
        ripple.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().power = 3.0f;
    }
	
    public void spawn()
    {
        GameObject.Instantiate(ripple, position, rotation);
        cooldown = 2.0f;
    }

	// Update is called once per frame
	void Update () {
		if (cooldown > 0)
        {
            cooldown -= .02f;
        }
        else
        {
            spawn();
            //print("spawn was run");
        }
	}
}
