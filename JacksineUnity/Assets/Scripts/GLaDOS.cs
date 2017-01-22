using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLaDOS : MonoBehaviour {

    public int foodCount;
    int foodInHole = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (foodInHole >= foodCount)
        {
            Camera.main.GetComponent<NoiseTransition>().BeginTransition();
            // LEVEL OVER
        }
	}

    public void FoodInHoleChange(int count)
    {
        foodInHole += count;
        Debug.Log(foodInHole);
    }
}
