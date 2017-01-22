using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {
	public Text startPrompt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		startPrompt.color = new Color(
			1,
			1,
			1,
			Mathf.Abs(Mathf.Sin( Time.time ))
		);

		if (Input.GetKeyDown("space") || Input.GetKey("up")) {
			SceneManager.LoadScene("maui");
		}
	
	}
}
