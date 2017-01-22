using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerFactory : MonoBehaviour {
	public Rock _rock;
	public Shark _shark;
	public Bird _bird;

	public float thret_level;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int threat_type;
		float threat_val;

		if (Random.Range(0F, 1F) > thret_level) {
			threat_type = Random.Range(0, 2);
			threat_val = Random.Range(0F, 1F);

			switch (threat_type) {
				case 0: sendThreat(_shark, threat_val);
					break;
				case 1: sendThreat(_rock, threat_val);
					break;
				case 2: sendThreat(_bird, threat_val);
					break;
			}
		}
		
	}

	public void sendThreat(Danger threat_type, float val) {
		Vector3 start_pos = threat_type.getStartPosFromSeed(val);
		Instantiate(threat_type, start_pos, Quaternion.identity);

	}
}
