﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreeTimer : MonoBehaviour {

	float timer = 60f; // 60
	Text myText;
	Text countdown;
	int count = 3;
	GameObject player;

	public AudioClip ticking;
	public AudioClip getReady;
	AudioSource aud;
	bool hasPlayed = false;
	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
		aud.PlayOneShot (getReady);
		player = GameObject.Find ("sheriff");
		myText = GetComponent<Text> ();
		countdown = GameObject.Find ("countdown").GetComponent<Text> ();


	}

	void Update(){
		myText.text = "" + System.Math.Round(timer, 1);
		if (countdown) 
		if (countdown.text != "GO") {
			countdown.text = "" + count;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Time.timeSinceLevelLoad < 4f) {
			player.GetComponent<Move> ().canMove = false;

			count = 3 - (int)Time.timeSinceLevelLoad;
			if (count == 0) {
				countdown.text = "GO";
			}
			player.GetComponent<Shoot> ().canShoot = false;
		} else {

			if (countdown) {
				Destroy (countdown);
			}
			
			player.GetComponent<Shoot> ().canShoot = true;
			player.GetComponent<Move> ().canMove = true;
		
			timer = timer - 0.0166f;

			if (timer < 0.04f) {
				GameObject manager = GameObject.FindGameObjectWithTag ("GameController");
				if (manager) {
					manager.GetComponent<GameM> ().lumberScore = GameObject.Find ("sheriff").GetComponent<TreeCount> ().count;
					manager.GetComponent<GameM> ().lumberCompleted = true;
					manager.GetComponent<GameM> ().overworldPos = new Vector3 (-3.03f, 2.85f, 14.95f);
					manager.GetComponent<GameM> ().overworldRotation = Quaternion.Euler(0, 180, 0);
				}
				SceneManager.LoadScene ("main");
			}
		
			if (timer < 30f && !hasPlayed) {
				aud.PlayOneShot (ticking);
				hasPlayed = true;
			}
		}


	}
}
