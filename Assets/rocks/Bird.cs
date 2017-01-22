using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Danger {

	public override Vector3 getStartPosFromSeed(float seed) {
		return new Vector3(
			20F,
			40F * seed,
			0F
		);
	}
}
