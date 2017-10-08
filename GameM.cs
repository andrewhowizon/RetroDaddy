using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour {


	public Vector3 overworldPos;
	public Quaternion overworldRotation;

	public int lumberScore;
	public bool lumberCompleted;

	public int pongScore;
	public bool pongCompleted;

	public int fishScore;
	public bool fishCompleted;

	public AudioClip welcome;
	AudioSource aud;

	// Use this for initialization
	void Awake () {
		// default pos in Overworld
		overworldPos = new Vector3 (3, 2, -10);
		overworldRotation = Quaternion.identity;

		lumberScore = 0;
		lumberCompleted = false;

		pongScore = 0;
		pongCompleted = false;

		fishScore = 0;
		fishCompleted = false;

		DontDestroyOnLoad (gameObject);
	}

	void Start() {
		aud = GetComponent<AudioSource> ();
		aud.PlayOneShot (welcome);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TeleSound() {
		GetComponent<AudioSource> ().Play();
	}
		
}
