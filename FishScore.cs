using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishScore : MonoBehaviour {

	public int score;

	Text fishScoreText;
	// Use this for initialization
	void Start () {
		score = 0;
		fishScoreText = GameObject.Find ("fishScoreText").GetComponent<Text> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		fishScoreText.text = "Fish Caught: " + score;
	}
}
