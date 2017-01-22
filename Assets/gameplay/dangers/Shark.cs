using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Danger {

	private float mai_thyme = 0;

	protected override void Update() {
		pos.y += 0.03F * Mathf.Sin((Time.time - mai_thyme) / 4);
		base.Update();
	}

	public override Vector3 getStartPosFromSeed(float seed) {
		mai_thyme = Time.time;
		isShark = true;
		return new Vector3(
			20F,
			11F * seed - 2F,
			0F
		);
	}
}
