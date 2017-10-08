using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VO : MonoBehaviour {

	AudioSource aud;

	public AudioClip q;
	public AudioClip w;
	public AudioClip e;
	public AudioClip r;
	public AudioClip t;
	public AudioClip y;
	public AudioClip a;
	public AudioClip s;
	public AudioClip d;
	public AudioClip f;
	public AudioClip g;
	public AudioClip h;

	float timer = 8f;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > timer) {
			int rnd = Random.Range(0,12);

			if (SceneManager.GetActiveScene ().name == "main" || SceneManager.GetActiveScene ().name == "first scene") {

				if (rnd == 0) {
					aud.PlayOneShot (q);
				} else if (rnd == 1) {
					aud.PlayOneShot (w);
				} else if (rnd == 2) {
					aud.PlayOneShot (e);
				} else if (rnd == 3) {
					aud.PlayOneShot (r);
				} else if (rnd == 4) {
					aud.PlayOneShot (t);
				} else if (rnd == 5) {
					aud.PlayOneShot (y);
				} else if (rnd == 6) {
					aud.PlayOneShot (a);
				} else if (rnd == 7) {
					aud.PlayOneShot (s);
				} else if (rnd == 8) {
					aud.PlayOneShot (d);
				} else if (rnd == 9) {
					aud.PlayOneShot (f);
				} else if (rnd == 10) {
					aud.PlayOneShot (g);
				} else if (rnd == 11) {
					aud.PlayOneShot (h);
				}

			}

			timer = Time.time + Random.Range (10f, 13f);
		}
	}
}
