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
			startPrompt.color.r,
			startPrompt.color.g,
			startPrompt.color.b,
			Mathf.Abs(Mathf.Sin( Time.time ))
		);

		if (Input.GetKeyDown("space") || Input.GetKey("up")) {
			SceneManager.LoadScene("maui");
		}
	
	}
}
