using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongScore : MonoBehaviour {

	public int score;

	Text pongScoreText;
	// Use this for initialization
	void Start () {
		score = 0;
		pongScoreText = GameObject.Find ("pongScoreText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		pongScoreText.text = "Points Scored: " + score;
	}
}
