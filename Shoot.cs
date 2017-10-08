using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	Vector3 hitLoc;
	Animator anim;
	Camera mainCam;
	AudioSource audioS;
	AudioSource gunS;

	public AudioClip treeCrack;

	public AudioClip gun1;
	public AudioClip gun2;
	public AudioClip gun3;

	public GameObject metalImpact;
	public GameObject brokenTree;

	public bool canShoot;

	// Use this for initialization
	void Start () {
		canShoot = true;
		gunS = GameObject.Find ("gunsounds").GetComponent<AudioSource> ();
		audioS = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		if (canShoot) {
			
			RaycastHit hit = new RaycastHit ();


			if (Input.GetKeyDown (KeyCode.Mouse0)) {
			
				// Raycast
				Physics.Raycast (mainCam.ScreenPointToRay (Input.mousePosition), out hit, 1000);

				/*
			for (int i = 0; i < hits.Length; i++) {
				if (hits [i].collider.tag == "GameFloor") {
					hitLoc = hits [i].point;
				}
			}
			*/
				hitLoc = hit.point;
				Vector3 tempLoc = hit.point;

				// Get angle from us
				tempLoc.y = transform.position.y;
				Vector3 targetDir = tempLoc - transform.position;
				float angle = Vector3.SignedAngle (targetDir, transform.forward, Vector3.up);

				// Debug.Log (angle);

				if (angle < 22.5f && angle > -22.5f) {
					anim.SetTrigger ("Straight");
				} else if (angle > -67.5f && angle < 22.5f) {
					anim.SetTrigger ("RightDiag");
				} else if (angle > -112.5f && angle < -67.5f) {
					anim.SetTrigger ("Right");
				} else if (angle > -157.5f && angle < -112.5f) {
					anim.SetTrigger ("RightBehind");
				} else if (angle > 157.5f || angle < -157.5f) {
					anim.SetTrigger ("Behind");
				} else if (angle > 112.5f && angle < 157.5f) {
					anim.SetTrigger ("LeftBehind");
				} else if (angle > 67.5f && angle < 112.5f) {
					anim.SetTrigger ("Left");
				} else if (angle > 22.5f && angle < 67.5f) {
					anim.SetTrigger ("LeftDiag");
				}

				GameObject newMetalImpact = Instantiate (metalImpact, hitLoc, Quaternion.identity);

				// Lumber level
				if (hit.collider.gameObject)
				if (hit.collider.gameObject.tag == "Tree") {
					GameObject newBrokenTree = Instantiate (brokenTree, hit.collider.gameObject.transform.position, Quaternion.identity);
					newBrokenTree.transform.localScale = hit.collider.gameObject.transform.localScale;
					Destroy (hit.collider.gameObject);
					GetComponent<TreeCount> ().SetTreesText (1);
					audioS.pitch = (Random.Range (0.6f, 0.9f));
					audioS.volume = (Random.Range (0.05f, 0.08f));
					audioS.PlayOneShot (treeCrack);
				}

				// Ponglevel

				if (hit.collider.gameObject.name == "playerBat") {
					if (hit.collider.transform.position.z <= -0.6609274f) {
						hit.collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 10f);
					} else {
						hit.collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -10f);
					}

					// Debug.Log (hit.collider.gameObject.GetComponent<Rigidbody> ().velocity);
				}


				// Fish level

				if (hit.collider.gameObject.tag == "Fish1") {
					GameObject.Find ("FishSpawn").GetComponent<SpawnFish> ().SpawnDead (1);
					Destroy (hit.collider.gameObject);
				} else if (hit.collider.gameObject.tag == "Fish2") {
					GameObject.Find ("FishSpawn").GetComponent<SpawnFish> ().SpawnDead (2);
					Destroy (hit.collider.gameObject);
				} else if (hit.collider.gameObject.tag == "Fish3") {
					GameObject.Find ("FishSpawn").GetComponent<SpawnFish> ().SpawnDead (3);
					Destroy (hit.collider.gameObject);
				}


				// Beachballs

				if (hit.collider.gameObject.tag == "BeachBall") {
					hit.collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range (-5f, 5f), 5f, Random.Range (-5f, 5f));
					hit.collider.gameObject.GetComponent<Rigidbody> ().AddTorque (Random.Range (-5f, 5f), 5f, Random.Range (-5f, 5f));
				}


				// Default sound
				gunS.pitch = (Random.Range (0.7f, 1f));
				gunS.volume = (Random.Range (0.02f, .03f));
				gunS.PlayOneShot (gun1);

			}

		}

		// Debug.Log (hitLoc);
	}
		
}
