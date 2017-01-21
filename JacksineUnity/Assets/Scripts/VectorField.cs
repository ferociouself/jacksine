using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorField : MonoBehaviour {

	public float forceMultiplier;
	public int width;
	public int height;
	public TextAsset vectorFile;

	public float applyForceThreshold;	// time between force application
	private float applyForceTimer;
	private Vector2[,] field;

	// Use this for initialization
	void Start () {
		string[] lines = vectorFile.text.Split ('\n');
		field = new Vector2[height, width];
		int r = 0;
		foreach (var line in lines) {
			string[] tokens = line.Split (' ');
			int i = 0;
			foreach (var token in tokens) {
				float val = float.Parse (token);
				if (i % 2 == 0) {
					field [r, i / 2].x = val;
				} else {
					field [r, i / 2].y = val;
				}
				i++;
			}
			r++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (applyForceTimer >= applyForceThreshold) {
			GameObject[] objs = GameObject.FindGameObjectsWithTag("Food");
			foreach (GameObject obj in objs) {
				var dx = obj.transform.position.x - this.transform.position.x;
				var dy = obj.transform.position.y - this.transform.position.y;
				Vector3 size = this.GetComponent<BoxCollider2D> ().bounds.size;
				var qx = (dx + size.x / 2) / size.x;
				var qy = (dy + size.y / 2) / size.y;

				var ix = (int)(qx * width);
				var iy = (int)(height - qy * height);

				if (ix >= 0 && ix <= width - 1 && iy >= 0 && iy <= height - 1) {
					Vector2 dir = field [iy, ix];
					obj.GetComponent<Rigidbody2D> ().AddForce (dir * forceMultiplier);
				}
			}
			applyForceTimer = 0.0f;
		}
		applyForceTimer += Time.deltaTime;
	}
}
