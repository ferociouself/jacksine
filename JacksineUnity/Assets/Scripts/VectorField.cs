using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorField : MonoBehaviour {

	public float forceMultiplier;		// coefficient for force vector to move the foods
	public float particleVelocityMultiplier;	// coefficient for velocity of background particles
	public int width;
	public int height;					// dimensions of vector field
	public bool willShiftHorizontally;	// whether the vector field will move horizontally during gameplay
	public bool willShiftVertically;	// whether the vector field will move vertically during gameplay
	public TextAsset vectorFile;		// reference to text field containing 2D width x height floats

	public float applyForceThreshold;	// time between force application
	public float particleApplyForceThreshold;	// time between setting particle velocity
	public float shiftFieldThreshold;	// time between moving vector field

	private float applyForceTimer;
	private float particleApplyForceTimer;
	private float shiftFieldTimer;
	private Vector2[,] field;
	private int shiftCounter = 0;
	private ParticleSystem.Particle[] particleBuffer;

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
		//
		particleBuffer = new ParticleSystem.Particle[1000];
	}

	Vector2 GetClosestVector(Vector3 objectPosition)
	{
		var dx = objectPosition.x - this.transform.position.x;
		var dy = objectPosition.y - this.transform.position.y;
		Vector3 size = this.GetComponent<BoxCollider2D> ().bounds.size;
		var qx = (dx + size.x / 2) / size.x;
		var qy = (dy + size.y / 2) / size.y;

		var ix = (int)(qx * width);
		var iy = (int)(height - qy * height);

		if (ix >= 0 && ix <= width - 1 && iy >= 0 && iy <= height - 1) {
			if (willShiftHorizontally) {
				ix = (ix + shiftCounter) % width;
			}
			if (willShiftVertically) {
				iy = (iy + shiftCounter) % height;
			}
			Vector2 dir = field [iy, ix];
			return dir;
		}
		return Vector2.zero;
	}

	// Update is called once per frame
	void Update () {
		if (shiftFieldTimer >= shiftFieldThreshold) {
			int num = (int)(shiftFieldTimer / shiftFieldThreshold);
			shiftCounter += num;
			shiftFieldTimer -= num * shiftFieldThreshold;
		}

		if (applyForceTimer >= applyForceThreshold) {
			GameObject[] objs = GameObject.FindGameObjectsWithTag("Food");
			foreach (GameObject obj in objs) {
				Vector2 dir = GetClosestVector (obj.transform.position);
				obj.GetComponent<Rigidbody2D> ().AddForce (dir * forceMultiplier);
			}
			applyForceTimer = 0.0f;
		}

		if (particleApplyForceTimer >= particleApplyForceThreshold) {
			GameObject ps = GameObject.FindGameObjectWithTag("BGParticle");
			if (ps != null) {
				var length = ps.GetComponent<ParticleSystem> ().GetParticles (particleBuffer);
				for (int x = 0; x < length; x++) {
					Vector2 dir = GetClosestVector (particleBuffer[x].position);
					particleBuffer[x].velocity = new Vector3 (particleVelocityMultiplier * dir.x, particleVelocityMultiplier * dir.y, 0f);
				}
				ps.GetComponent<ParticleSystem> ().SetParticles (particleBuffer, length);
			}
			particleApplyForceTimer = 0.0f;
		}

		applyForceTimer += Time.deltaTime;
		particleApplyForceTimer += Time.deltaTime;
		shiftFieldTimer += Time.deltaTime;
	}
}
