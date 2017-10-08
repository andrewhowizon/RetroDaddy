using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour {

	Vector3 spawn;
	float timer;

	public GameObject fish1;
	public GameObject fish2;
	public GameObject fish3;

	public GameObject deadfish1;
	public GameObject deadfish2;
	public GameObject deadfish3;

	public GameObject fishdump;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timer) {
			// do x
			float rnd = Random.value;

			GameObject fish;

			if (rnd < .33f) {
				fish = fish1;
			} else if (rnd < .66f) {
				fish = fish2;
			} else {
				fish = fish3;
			}


			int spawnRnd = Random.Range (0, transform.childCount);
			spawn = transform.GetChild (spawnRnd).transform.position;


			Instantiate (fish, spawn, fish.transform.rotation);
			timer = Time.time + .5f;
		}
	}

	public void SpawnDead(int n) {
		GameObject deadFish;
		if (n == 1) {
			deadFish = deadfish1;
		} else if (n == 2) {
			deadFish = deadfish2;
		} else if (n == 3) {
			deadFish = deadfish3;
		} else {
			return;
		}

		deadFish = Instantiate (deadFish, fishdump.transform.position, Quaternion.Euler(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359)));

		GameObject.Find ("fishScore").GetComponent<FishScore> ().score += 1;

		AudioSource tempAud = GameObject.Find ("fishScore").GetComponent<AudioSource> ();
		tempAud.PlayOneShot (tempAud.clip);
		tempAud.pitch = Random.Range (.9f, 1.1f);
		tempAud.volume = Random.Range (.2f, .25f);
		// deadFish.GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range (-3f, 3f), Random.Range (-3f, 3f), Random.Range (-3f, 3f));
	}
}
