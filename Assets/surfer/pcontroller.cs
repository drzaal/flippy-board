using UnityEngine;
using System.Collections;

public class pcontroller : MonoBehaviour {
	public float theta = 0;
	public float tip_rate = 82.0F;
	public float high_bound = 90F;
	public float low_bound = -90F;
	public float lerp_factor = 32F;


	// Use this for initialization
	void Start () {
	
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

		// transform.rotation.SetEulerRotation (Vector3.forward * theta);
		// Rotate(Vector3.forward * theta * Mathf.PI);

	}
}
