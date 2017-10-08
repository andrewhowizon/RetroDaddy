using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

	Rigidbody rb;
	Transform surface;
	float speed = 5;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (Random.Range (-10f, -5f), 0, Random.Range (-.5f, 1f));
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Respawn") {
			Destroy (gameObject);
		}
	}

}
