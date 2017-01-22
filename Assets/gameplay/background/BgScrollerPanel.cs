using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScrollerPanel : MonoBehaviour {
	private SpriteRenderer sr;
	private float w;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();

		w = sr.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -w) transform.position += Vector3.right * 2F * w;
		if (transform.position.x > w) transform.position -= Vector3.right * 2F * w;
	}
}
