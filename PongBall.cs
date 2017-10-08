using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour {

	float speed = 10f;

	Rigidbody rb;
	float timer;
	string lastHit;

	public AudioClip blip;
	AudioSource audioS;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = Vector3.right * speed;

		audioS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Time.time > timer) {
			rb.velocity = rb.velocity.normalized * speed;
			timer = float.MaxValue;
		}

		if (lastHit == "playerBat" && rb.velocity.x > -8f) {
			rb.velocity = new Vector3 (-8f, rb.velocity.y, rb.velocity.z);
		} else if (lastHit == "computer" && rb.velocity.x < 8f) {
			rb.velocity = new Vector3 (8f, rb.velocity.y, rb.velocity.z);
		}

		//Debug.Log (rb.velocity);

	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "bounce") {

			if (col.gameObject.name == "playerBat" || col.gameObject.name == "computer") {
				lastHit = col.gameObject.name;


				timer = Time.time + 0.01f;
			}




		}

		if (col.gameObject.name == "leftwall") {
			Instantiate (gameObject, new Vector3(0.8169517f, 0.7701979f, -0.6803849f), Quaternion.Euler(-90, 0 ,0));
			Destroy (gameObject);
			//Debug.Log ("left");
			GameObject.Find("pongScore").GetComponent<PongScore>().score += 1;
			GameObject.Find ("pongScore").GetComponent<AudioSource> ().Play();
		}

		if (col.gameObject.name == "rightwall") {
			Instantiate (gameObject, new Vector3(0.8169517f, 0.7701979f, -0.6803849f), Quaternion.Euler(-90, 0 ,0));
			Destroy (gameObject);
			//Debug.Log ("right");
		}

		audioS.PlayOneShot (blip);

		if (col.gameObject.name == "computer") {
			rb.velocity += new Vector3(0, 0, Random.Range(-2f,2f));
		}
	}
		
}
