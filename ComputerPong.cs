using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPong : MonoBehaviour {

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GameObject.FindGameObjectWithTag ("pongball")) {

			if (GameObject.FindGameObjectWithTag("pongball").transform.position.z > transform.position.z) {
				rb.velocity = new Vector3 (0, 0, Mathf.Lerp(rb.velocity.z, 2f, 0.05f));
			} else {
				rb.velocity = new Vector3 (0, 0, Mathf.Lerp(rb.velocity.z, -2f, 0.05f));
			}

		}
	}
}
