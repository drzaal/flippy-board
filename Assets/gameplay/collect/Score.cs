using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	int score;
	Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ""+score;
	}

	public static Score operator ++ (Score score) {
		score.score++;
		return score;
	}

	public void Reset(){
		score = 0;
	}

	public void OnDed() {
		if (score > HiScore){
			HiScore = score;
		}
	}

	int HiScore {
		get {
			return PlayerPrefs.GetInt("HiScore", 0);
		}
		set {
			PlayerPrefs.SetInt("HiScore", value);
		}
	}
}
