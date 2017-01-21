using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorField : MonoBehaviour {

	public float forceMultiplier;		// coefficient for force vector to move the foods
	public int width;
	public int height;					// dimensions of vector field
	public bool willShiftHorizontally;	// whether the vector field will move horizontally during gameplay
	public bool willShiftVertically;	// whether the vector field will move vertically during gameplay
	public TextAsset vectorFile;		// reference to text field containing 2D width x height floats

	public float applyForceThreshold;	// time between force application
	public float shiftFieldThreshold;	// time between moving vector field

	private float applyForceTimer;
	private float shiftFieldTimer;
	private Vector2[,] field;
	private int shiftCounter = 0;

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
					if (shiftFieldTimer >= shiftFieldThreshold) {
						int num = (int)(shiftFieldTimer / shiftFieldThreshold);
						shiftCounter += num;
						shiftFieldTimer -= num * shiftFieldThreshold;
					}
					if (willShiftHorizontally) {
						ix = (ix + shiftCounter) % width;
					}
					if (willShiftVertically) {
						iy = (iy + shiftCounter) % height;
					}
					Vector2 dir = field [iy, ix];
					obj.GetComponent<Rigidbody2D> ().AddForce (dir * forceMultiplier);
				}
			}
			applyForceTimer = 0.0f;
		}
		applyForceTimer += Time.deltaTime;
		shiftFieldTimer += Time.deltaTime;
	}
}
