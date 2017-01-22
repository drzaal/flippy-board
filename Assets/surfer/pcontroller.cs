using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class pcontroller : MonoBehaviour {

	public bool keyDown;

	public float theta = 0;
	public float tip_rate = 82.0F;
	public float high_bound = 90F;
	public float low_bound = -90F;
	public float lerp_factor = 32F;
	public float bail_threshold = 50F;

	public float dead_spin = 90F;
	public float die_drop;
	public float die_pop;

	public string state;

	public float board_speed;
	public float drift_back;
	public float gravity;

	public Vector3 pos;
	public Vector2 v;
	public bool airtime = false;

	public AudioClip[] sfx_list;
	public string[] sfx_names;
	public Dictionary<string, AudioClip> sfx_map;
	public AudioSource sfx;

	public Text gtxt;
	public Text gtimedown;

	public float gameover_timer;
	public static pcontroller main;

	// Use this for initialization
	void Start () {
		main = this;
		sfx_map = mapSfx();
		sfx = GetComponent<AudioSource>();

		transform.position = Vector3.up * -20F;
		pos = transform.position;

		onYourMark();
	}
	
	Dictionary<string, AudioClip> mapSfx() {
		Dictionary<string, AudioClip> sm = new Dictionary<string, AudioClip>();
		int i = 0, imax = sfx_list.Length, jmax = sfx_names.Length;
		for (i=0; i< Mathf.Min(imax, jmax); i++) {
			//sfx_map.Add(sfx_names[i], sfx_list[i]);
		}

		return sm;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (Input.GetKeyDown("space") || Input.GetKeyDown("up")) {
			keyDown = true;
		}
		if (Input.GetKeyUp("space") || Input.GetKeyUp("up")) {
			keyDown = false;
		}
		*/
		// transform.rotation.SetEulerRotation (Vector3.forward * theta);
		// Rotate(Vector3.forward * theta * Mathf.PI);

		if (state == "onyourmark") getReady();
		if (state == "happysurf") crestSurf();
		if (state == "ded") youDed();
		if (state == "continue") askContinue();
	}

	void onYourMark() {
		v = Vector2.zero;
		gameover_timer = 3;
		gtxt.enabled = true;
		gtimedown.enabled = true;
		gtxt.text = "Dudes and Dudettes\r\nGet Ready to Get Gnarly!";
		state = "onyourmark";
	}

	void enableContinueCountdown() {
		v = Vector2.zero;
		gtxt.text = "Are you Bad Enough\r\nTo Continue?";
		gameover_timer = 10;
		gtxt.enabled = true;
		gtimedown.enabled = true;
		state = "continue";
	}

	void startSurf() {
		gameover_timer = 10;
		state = "happysurf";
		pos = new Vector3(0, wavy.getCrestY(0), pos.z);
		v = Vector2.right;
		gtxt.enabled = false;
		gtimedown.enabled = false;
	}

	void crestAirtime() {
		v = new Vector2(
			v.x,
			v.y - Time.deltaTime * gravity
		);
	}

	void crestCarving(float crestY) {

		//float delAngl = Mathf.DeltaAngle(theta, wavy.getCrestAngle(pos.x));

		Vector2 yaw = Quaternion.Euler(0, 0, theta) * Vector2.right;

		float carve = Vector2.Dot(v, yaw);
		float bail = Mathf.Pow(Vector2.Angle(v, yaw) / 180, 2) * v.magnitude;

		if (bail > bail_threshold) { // Disable bail
			oNoes();
		}

		//v =  v + board_speed * Vector2.one * Vector2.
		v = 0.95F * v + (board_speed * yaw) * Time.deltaTime;
	}

	void crestSurf() {

		float crestY = wavy.getCrestY(pos.x);

		if (pos.y < crestY) {
			//if (airtime) sfx.PlayOneShot(sfx_map["crest"]);
			airtime = false;
		} else {
			//if (!airtime) sfx.PlayOneShot(sfx_map["crest"]);
			airtime = true;
		}

		//transform.rotation.t;
		if (Input.GetKey("up") || Input.GetKey("space")) {
			theta = Mathf.Lerp(theta, high_bound, lerp_factor * Time.deltaTime);
		} else {
			theta = Mathf.Lerp(theta, low_bound, lerp_factor * Time.deltaTime);
		}
		transform.rotation = Quaternion.Euler(Vector3.forward * theta);

		if (airtime) {
			crestAirtime();
		} else {
			crestCarving(crestY);
		}
		
		pos = new Vector3(
			pos.x, // + v.x*Time.deltaTime, just 2d for now
			pos.y + v.y*Time.deltaTime,
			pos.z
		);

		transform.position = pos;

		if (pos.y < -5F) oNoes();
	}

	void oNoes() {
		state = "ded";
		v.y = die_pop;
		theta = 0;
		sfx.Play();
	}

	void youDed() {
		v.y -= Time.deltaTime * die_drop;

		pos = new Vector3(
			pos.x,
			pos.y + v.y*Time.deltaTime,
			pos.z
		);

		transform.position = pos;

		transform.rotation = Quaternion.Euler(Vector3.forward * Time.time * dead_spin);

		if (pos.y < -10F) {
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
		if (Input.GetKeyDown("space") || Input.GetKeyDown("up")) {
			startSurf();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (state == "happysurf") oNoes();

	}
}
