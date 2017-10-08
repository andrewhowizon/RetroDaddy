using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject a = transform.GetChild (0).gameObject;

		transform.GetChild (0).transform.parent = null;

		a.GetComponent<Rigidbody> ().velocity = new Vector3(Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f));

		// -----

		a = transform.GetChild (0).gameObject;

		transform.GetChild (0).transform.parent = null;

		a.GetComponent<Rigidbody> ().velocity = new Vector3(Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
