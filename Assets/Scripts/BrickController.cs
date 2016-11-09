using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision collision) {
		GameObject gameObject = collision.gameObject;
		if (gameObject.CompareTag ("Ball")) {
			Destroy (this.gameObject);
			GameController.score_counter++;
		}
	}
}
