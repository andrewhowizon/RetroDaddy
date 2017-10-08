using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChar : MonoBehaviour {

	Transform target;

	Vector3 currentVelocity;
	float smoothTime = 0.2f;

	Vector3 fixedUpdateTarget;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("sheriff").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target) {
			//fixedUpdateTarget = Vector3.SmoothDamp (transform.position, target.position, ref currentVelocity, smoothTime);
			transform.position = Vector3.SmoothDamp (transform.position, target.position, ref currentVelocity, smoothTime);
		}
	}

	void Update() {
		//transform.position = fixedUpdateTarget;
	}
}
