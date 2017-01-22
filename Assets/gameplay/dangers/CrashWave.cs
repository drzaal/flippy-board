using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashWave : Danger {
	public float wave_speed = 5F;

	public static CrashWave main;
	
	void Start() {
		main = this;
		pos = transform.position;

	}
	protected override void Update() {
		if (pcontroller.main.state == "happysurf") {
			if (transform.position.x < -15F) {
				pos += Vector3.right * (wave_speed) * Time.deltaTime;
			} else {
				pos += Vector3.right * (wave_speed - pcontroller.main.v.x) * Time.deltaTime;
			}
		}
		else {
			pos = new Vector3( -10F, pos.y, pos.z );
		}

		transform.position = pos;
	}
}
