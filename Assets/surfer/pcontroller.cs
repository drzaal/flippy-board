using UnityEngine;
using System.Collections;

public class pcontroller : MonoBehaviour {
	public float theta = 0;
	public float tip_rate = 82.0F;
	public float high_bound = 90F;
	public float low_bound = -90F;
	public float lerp_factor = 32F;


	public float board_speed;
	public float drift_back;

	public Vector3 pos;
	public float vx;


	// Use this for initialization
	void Start () {
		pos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation.t;
		if (Input.GetKey("space")) {
			theta = Mathf.Lerp(theta, high_bound, lerp_factor * Time.deltaTime);

		} else {
			theta = Mathf.Lerp(theta, low_bound, lerp_factor * Time.deltaTime);

		}

		// Mathf.LerpAngle()
		transform.rotation = Quaternion.Euler(Vector3.forward * theta);

		

		vx =  -drift_back * (Mathf.DeltaAngle(theta, wavy.getCrestAngle(pos.x)) / 180) + board_speed;
		pos = new Vector3(
			pos.x + vx*Time.deltaTime,
			wavy.getCrestY(pos.x),
		pos.z);

		transform.position = pos;
		// transform.rotation.SetEulerRotation (Vector3.forward * theta);
		// Rotate(Vector3.forward * theta * Mathf.PI);

	}
}
