using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Danger {

	public override Vector3 getStartPosFromSeed(float seed) {
		return new Vector3(
			20F,
			35F * seed - 5F,
			0F
		);
	}
}
