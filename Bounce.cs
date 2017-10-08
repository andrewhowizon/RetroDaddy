using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	float speed = 10f;

	Rigidbody rb;
	float timer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Time.time > timer) {
			rb.velocity = rb.velocity.normalized * speed;
			timer = float.MaxValue;
		}

		//Debug.Log (rb.velocity);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "bounce") {
			timer = Time.time + 0.01f;
		}
	}
}
