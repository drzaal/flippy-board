using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Danger {

	public override Vector3 getStartPosFromSeed(float seed) {
		return new Vector3(
			20F,
			20F * seed + 5F,
			0F
		);
	}
}
