using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFactory : MonoBehaviour {
	public Collect collect;
	public float timeBetweenCollects = 5;

	float lastGenerateTime = 0;

	// Use this for initialization
	void Start () {
		lastGenerateTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - lastGenerateTime;
		if (t > timeBetweenCollects) {
			sendCollect(collect, Time.time);
			lastGenerateTime = Time.time;
		}
	}

	public void sendCollect(Collect collect_type, float val) {
		Vector3 start_pos = collect_type.getStartPosFromSeed(val);
		Instantiate(collect_type, start_pos, Quaternion.identity);

	}
}
