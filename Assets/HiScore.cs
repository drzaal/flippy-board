using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int hiScore = PlayerPrefs.GetInt("HiScore");
		if (hiScore > 0){
			Text text = GetComponent<Text>();
			text.text = "hi score: "+hiScore;
		} else {
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
