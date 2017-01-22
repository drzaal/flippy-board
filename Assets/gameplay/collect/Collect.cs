using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {
	public Vector3 pos;

	Vector3 topRight;
	Vector3 bottomRight;

	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		pos -= Vector3.right * (pcontroller.main.v.x * Time.deltaTime);

		transform.position = pos;

		if (pos.x < -20F) {
			pos = new Vector3(
				20F,
				pos.y,
				pos.z
			);
			Destroy(gameObject);
		}

		if (pcontroller.main.state != "happysurf") Destroy(gameObject);
	}

	public virtual Vector3 getStartPosFromSeed(float seed) {
		topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
		bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		Random.InitState(Mathf.FloorToInt(seed));
		Vector3 result = topRight + (bottomRight - topRight) * Random.value;
		result.z = 0;
		return result;
	}
}
