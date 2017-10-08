using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {

	CharacterController CC;

	float speed = .25f;
	float horizontal;
	float vertical;

	float camSize;
	Camera cam;

	Animator anim;

	public bool canMove;

	// Use this for initialization
	void Start () {
		canMove = true;

		camSize = Camera.main.orthographicSize;
		cam = Camera.main;
		CC = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();

		GameObject GameM = GameObject.Find ("GameM");

		if (GameM) {
			if (SceneManager.GetActiveScene ().name == "main") {
				transform.position = GameM.GetComponent<GameM> ().overworldPos;
				transform.rotation = GameM.GetComponent<GameM> ().overworldRotation;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw ("Horizontal");
		vertical = Input.GetAxisRaw ("Vertical");

		if (Time.time < 1f) {
			canMove = false;
		} else {
			canMove = true;
		}

	}

	void FixedUpdate () {
		Vector3 moveDir = new Vector3 ();
		moveDir.x = horizontal;
		moveDir.z = vertical;
		moveDir.y = -1f;

		moveDir = moveDir.normalized;


		if (canMove) {
			CC.Move (moveDir * speed);
		}



		// Debug.Log (CC.velocity);
		// Face direction of travel
		moveDir.y = 0;
		if (moveDir != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation (moveDir);
			anim.SetBool ("Run", true);
			//cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, camSize * 1.05f, 0.01f);
		} else {
			anim.SetBool ("Run", false);
			//cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, camSize, 0.01f);
		}
			

	}
}
