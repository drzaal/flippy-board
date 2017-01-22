using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Danger {

	protected override void Update() {
		pos.y += 5F * Mathf.Sin(Time.deltaTime / 8);
		base.Update();
	}

	public override Vector3 getStartPosFromSeed(float seed) {
		return new Vector3(
			20F,
			30F * seed - 5F,
			0F
		);
	}
}
