using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class pcontroller : MonoBehaviour {
	public float theta = 0;
	public float tip_rate = 82.0F;
	public float high_bound = 90F;
	public float low_bound = -90F;
	public float lerp_factor = 32F;

	public float dead_spin = 90F;
	public float die_drop;
	public float die_pop;

	public string state;

	public float board_speed;
	public float drift_back;

	public Vector3 pos;
	public float vx;

	public Text gtxt;
	public Text gtimedown;

	public float gameover_timer;

	// Use this for initialization
	void Start () {
		transform.position = Vector3.up * -20F;
		pos = transform.position;

		onYourMark();
	}
	
	// Update is called once per frame
	void Update () {
		// transform.rotation.SetEulerRotation (Vector3.forward * theta);
		// Rotate(Vector3.forward * theta * Mathf.PI);

		if (state == "onyourmark") getReady();
		if (state == "happysurf") happySurf();
		if (state == "ded") youDed();
		if (state == "continue") askContinue();
	}

	void onYourMark() {
		vx = 0;
		gameover_timer = 3;
		gtxt.enabled = true;
		gtimedown.enabled = true;
		gtxt.text = "Dudes and Dudettes\r\nGet Ready to Get Gnarly!";
		state = "onyourmark";
	}

	void enableContinueCountdown() {
		vx = 0;
		gtxt.text = "Are you Bad Enough\r\nTo Continue?";
		gameover_timer = 10;
		gtxt.enabled = true;
		gtimedown.enabled = true;
		state = "continue";
	}

	void startSurf() {
		gameover_timer = 10;
		state = "happysurf";
		pos = new Vector3(0, pos.y, pos.z);
		gtxt.enabled = false;
		gtimedown.enabled = false;
	}

	void happySurf() {

		//transform.rotation.t;
		if (Input.GetKey("space")) {
			theta = Mathf.Lerp(theta, high_bound, lerp_factor * Time.deltaTime);

		} else {
			theta = Mathf.Lerp(theta, low_bound, lerp_factor * Time.deltaTime);

		}

		// Mathf.LerpAngle()
		transform.rotation = Quaternion.Euler(Vector3.forward * theta);

		
		float delAngl = Mathf.DeltaAngle(theta, wavy.getCrestAngle(pos.x));

		vx =  -drift_back * (delAngl / 180) + board_speed;
		
		pos = new Vector3(
			pos.x + vx*Time.deltaTime,
			wavy.getCrestY(pos.x),
		pos.z);

		transform.position = pos;

		if (Mathf.Abs(delAngl) > 70) {
			oNoes();
		}
	}

	void oNoes() {
			state = "ded";
			vx = die_pop;
			theta = 0;
	}

	void youDed() {
		vx -= Time.deltaTime * die_drop;

		pos = new Vector3(
			pos.x,
			pos.y + vx*Time.deltaTime,
			pos.z
		);

		transform.position = pos;

		transform.rotation = Quaternion.Euler(Vector3.forward * Time.time * dead_spin);

		if (pos.y < -50F) {
			enableContinueCountdown();
		}
	}

	void getReady() {

		gameover_timer -= Time.deltaTime;

		gtimedown.text = Mathf.Ceil(gameover_timer).ToString();
		if (gameover_timer <= 0 ) {
			startSurf();
		}
	}

	void askContinue() {
		gameover_timer -= Time.deltaTime;

		gtimedown.text = Mathf.Ceil(gameover_timer).ToString();

		if (gameover_timer <= 0 ) {
			state = "gameover";
			SceneManager.LoadScene("title");
			return;
		}
		if (Input.GetKeyDown("space")) {
			startSurf();
		}
	}
}
