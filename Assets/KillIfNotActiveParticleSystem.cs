using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillIfNotActiveParticleSystem : MonoBehaviour {
	ParticleSystem psys;

	// Use this for initialization
	void Start () {
		psys = GetComponent<ParticleSystem>();
		if (!psys){
			Kill();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!psys.IsAlive()){
			Kill();
		}
	}

	void Kill(){
		Destroy(gameObject);
	}
}
