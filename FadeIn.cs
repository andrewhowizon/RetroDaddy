using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!GetComponent<AudioSource> ().isPlaying) {
			GetComponent<AudioSource> ().Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
