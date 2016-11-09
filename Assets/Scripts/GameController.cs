using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class GameController : MonoBehaviour {
	public GameObject prefab;
	public GameObject ballPrefab;

	public float gridX = 5f;
	public float gridY = 5f;
	public float spacing = 1;
	public Text score;
	public Text time;
	public static int score_counter;
	public int WinScore;
	public int timeSeconds;
	System.Timers.Timer t;

	void onTimer(object source, ElapsedEventArgs e){
		timeSeconds--;
	}

	void Start() {
		t = new Timer ();
		t.Elapsed += new ElapsedEventHandler (onTimer);
		t.Interval = 1000;
		t.Start ();
		score_counter = 0;
		for (int y = 0; y < 10; y++) {
			for (int x = 0; x < 12; x++) {
				Vector3 pos = new Vector3( x, 0, 10 + y) * spacing;
				Instantiate(prefab, pos, Quaternion.identity);
			}
		}
		WinScore = 10 * 12;
	}
	void Update(){
		score.text = score_counter.ToString ();
		time.text = timeSeconds.ToString ();
		CheckWin ();
	}
	void OnTriggerExit(Collider other) {
		print ("OnTriggerExit with object" + other.gameObject.tag);
		if (other.gameObject.CompareTag ("Ball")) {
			print ("OnTriggerExit if statement");
			GameObject ball = other.gameObject;


			ball.transform.position = new Vector3(10,0,10);
			Rigidbody ballRb = ball.GetComponent<Rigidbody> ();
			ballRb.velocity = new Vector3 (0,0,0);
			ballRb.AddForce (new Vector3 (1, 0, 1) * 20);
			score_counter -= 10;
		}
	}
	void CheckWin(){
		if(timeSeconds == 0)
		{
			Win ();
		}
		if (score_counter == WinScore) {
			Win ();
		}

	}
	void Win(){
		t.Stop ();
		time.text = "Game Over";
	}
}
