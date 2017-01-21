using UnityEngine;
using System.Collections;

/*
 ok so anything in comments like this is supposed to be what each part of the program is supposed to do. However it doesn't currently do this because
 this is my second time in unity
     */

public class attract : MonoBehaviour
{      //aight this method is supposed to apply force to an object when its collider hits the circle collider

    // Use this for initialization
    void Start()
    {

    }


    public  void OnTriggerEnter2D(Collider2D blob) //the object will be called blob, and this is supposed to signify the event triggerring when the blob collider hits this collider
    {
        pull(blob);
        //print("Collision Detected.");
    }


    public  void OnTriggerStay2D(Collider2D blob) //this is like before but is supposed to indicate that the same method stays when the obect stays
    {
        pull(blob);
        //print("Object Stayed.");
    }

    /*
     ok so this method is supposed to apply two forces- one in the x axis (right) and one in the y axis (up)
            using the positions of both this object and the blob is supposed to make sure the force is negative, when appropriate
            right now I'm not adding a magnitude to the force because there's already a magnitude due to the positions of the objects
                this value can be changed when the forces actually work
         */
    public void pull(Collider2D blob)
    {
        blob.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -(blob.GetComponent<Rigidbody2D>().transform.position.x - this.transform.position.x));
        blob.GetComponent<Rigidbody2D>().AddForce(Vector2.up * -(blob.GetComponent<Rigidbody2D>().transform.position.y - this.transform.position.y));
        //print("Pull method activated.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
