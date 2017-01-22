using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRippleSpawner : MonoBehaviour {
    Vector2 position;
    Quaternion rotation;
    public GameObject ripple;
    float cooldown;

    // Use this for initialization
    void Start ()
    {
        position = new Vector2(this.transform.position.x, this.transform.position.y);
        rotation = new Quaternion(0, 0, 0, 0);
        cooldown = 0f;
        ripple.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        ripple.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().constant = -1.0f;
        ripple.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().power = 0.005f;
        ripple.transform.GetChild(0).gameObject.GetComponent<RippleHitObject>().timeleft = 0.5f;
        Vector2 dir = new Vector2((float)Random.Range(50, 150), (float)Random.Range(50, 150));
        this.GetComponent<Rigidbody2D>().AddForce(dir);
    }
	
    void spawn()
    {
        Vector2 loc = new Vector2(this.transform.position.x, this.transform.position.y);
        position = loc;
        GameObject.Instantiate(ripple, position, rotation);
        cooldown = 0.04f;
    }

	// Update is called once per frame
	void Update () {
        if (cooldown > 0)
        {
            cooldown -= .02f;
        }
        else
        {
            if (this.transform.position.x < 2 && this.transform.position.y < 5)
                spawn();
            //print("spawn was run");
        }
    }
}
