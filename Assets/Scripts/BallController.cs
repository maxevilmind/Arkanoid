using UnityEngine;
using System.Collections;
using System;

public class BallController : MonoBehaviour {
	public int initialForceMultiplier = 1;
	public Rigidbody rigidbody;
	public float InputForceScale = 10.0f;
	private AudioSource audioSource;
	public AudioClip WallSound;
	public AudioClip PaddleSound;
	public AudioClip BrickSound;

	// Use this for initialization
	void Start () {
		Vector3 force = 
			Quaternion.Euler(0, (int)UnityEngine.Random.Range(-30,30), 0)*
			Vector3.forward;
		force = force * InputForceScale;
		rigidbody.AddForce (force);
		audioSource = GetComponent<AudioSource> ();


	}
	void OnCollisionEnter(Collision collision) {
		GameObject gameObject =
			collision.gameObject;
		if (gameObject.CompareTag ("Wall")) {
			audioSource.PlayOneShot (WallSound);
		} else if (gameObject.CompareTag ("Paddle")) {
			audioSource.PlayOneShot (PaddleSound);
		} else if (gameObject.CompareTag ("Brick")) {
		audioSource.PlayOneShot (BrickSound);
		}
	}

}
