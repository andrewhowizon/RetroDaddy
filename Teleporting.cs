using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporting : MonoBehaviour {

	bool colliding = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		colliding = false;
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "LumberTele" && !colliding) {
			GameObject.Find ("GameM").GetComponent<GameM> ().TeleSound ();
			SceneManager.LoadScene ("lumber");
			Debug.Log ("lumber");
			colliding = true;


		}

		if (hit.gameObject.tag == "PongTele" && !colliding) {
			GameObject.Find ("GameM").GetComponent<GameM> ().TeleSound ();
			SceneManager.LoadScene ("pong");
			Debug.Log ("pong");
			colliding = true;
		}

		if (hit.gameObject.tag == "FishTele" && !colliding) {
			GameObject.Find ("GameM").GetComponent<GameM> ().TeleSound ();
			SceneManager.LoadScene ("fish");
			Debug.Log ("fish");
			colliding = true;
		}
	}
}
