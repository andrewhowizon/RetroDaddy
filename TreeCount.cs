using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeCount : MonoBehaviour {

	Text treesText;
	public int count;
	// Use this for initialization
	void Start () {
		count = 0;
		treesText = GameObject.Find ("treesText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTreesText(int n) {
		count += n;
		treesText.text = "Trees Blasted: " + count;
	}
}
