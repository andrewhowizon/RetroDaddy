using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInMusic : MonoBehaviour {

	AudioSource aud;
	public AudioClip one;
	public AudioClip two;
	public AudioClip three;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
		aud.volume = 0;

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		aud.volume = Mathf.Lerp (aud.volume, .05f, 0.01f);

		if (!aud.isPlaying) {
			aud.volume = 0;
			float rnd = Random.value;

			if (rnd < .33f) {
				aud.PlayOneShot (one);
			} else if (rnd < .66f) {
				aud.PlayOneShot (two);
			} else {
				aud.PlayOneShot (three);
			}
		}
	}
}
