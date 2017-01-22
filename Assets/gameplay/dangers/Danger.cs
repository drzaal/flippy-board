using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour {
	public Vector3 pos;
	public bool isShark = false;

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
			//Destroy(gameObject);
		}

		if (pcontroller.main.state != "happysurf") Destroy(gameObject);
	}

	public virtual Vector3 getStartPosFromSeed(float seed) {
		isShark = false;
		return Vector3.zero;
	}
}
