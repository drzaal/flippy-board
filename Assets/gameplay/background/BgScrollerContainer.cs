using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScrollerContainer : MonoBehaviour {

	public float far_speed;
	public float near_speed;

	public GameObject far_bg_1;
	public GameObject near_bg_1;
	public GameObject far_bg_2;
	public GameObject near_bg_2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		far_bg_1.transform.position += Vector3.right * far_speed * Time.deltaTime;
		near_bg_1.transform.position += Vector3.right * near_speed * Time.deltaTime;

		far_bg_2.transform.position += Vector3.right * far_speed * Time.deltaTime;
		near_bg_2.transform.position += Vector3.right * near_speed * Time.deltaTime;

	}
}
