using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embiggener : MonoBehaviour {

    public float bigSpeed = 1.01f;
    public float maxSize = 2.0f;
    public float sinDampener = 20.0f;

    float curSize = 1.0f;

    float sinRot = 0.0f;
    public float sinOffset = 0.0f;

    float curSizeInc;

	// Use this for initialization
	void Start () {
        sinRot += sinOffset;
	}
	
	// Update is called once per frame
	void Update () {
        curSizeInc = bigSpeed + Mathf.Abs((Mathf.Sin(sinRot) / sinDampener));
        transform.localScale *= curSizeInc;
        curSize *= curSizeInc;
        if (curSize > maxSize)
        {
            GameObject.Destroy(this.gameObject);
        }
        float sizeRatio = 1 - (curSize / maxSize);
        Color curColor = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(curColor.r, curColor.g, curColor.b, sizeRatio);
        sinRot += Time.deltaTime * 10.0f;
	}

    public float getCurSizeInc()
    {
        return curSizeInc;
    }
}
