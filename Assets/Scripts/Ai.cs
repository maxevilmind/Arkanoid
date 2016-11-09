using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {
	public float multiplier = 1.0f;
	public int collisionAngleMultiplier = 1;
	Rigidbody rigidbody;
	public Rigidbody ball;
	public int ForceMultiplier;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.position.x < rigidbody.position.x) {
			rigidbody.AddForce (new Vector3 (-1 * ForceMultiplier, 0, 0));
		} else if (ball.position.x >= rigidbody.position.x) {
			rigidbody.AddForce (new Vector3 (1 * ForceMultiplier, 0, 0));
		} else
		if (ball.position.z < rigidbody.position.x) {
				rigidbody.AddForce (new Vector3 (-1 * ForceMultiplier, 0, 0));
		} else if (ball.position.z >= rigidbody.position.x) {
				rigidbody.AddForce (new Vector3 (1 * ForceMultiplier, 0, 0));
		}

	}

	void OnCollisionEnter(Collision collision) {
		GameObject gameObject = collision.gameObject;
		if (gameObject.CompareTag ("Ball")) {
			GameObject ball = gameObject;
			BallController ballController = ball.GetComponent<BallController> ();
			float shift = ball.transform.position.x - transform.position.x;
			Vector3 force = new Vector3 (1, 0, 0) * shift * collisionAngleMultiplier;
			ball.GetComponent<Rigidbody> ().AddForce (force);
		}
	}
}
