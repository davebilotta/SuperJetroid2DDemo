using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour {

	public string scene;
	private bool loadLock; // lock transition once player clicks, this way multiple click requests don't get queued

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && !loadLock) { 
			LoadScene();
		}
	}

	void LoadScene() { 
		loadLock = true; 
	
		// formerly Application.LoadLevel(scene) 
		SceneManager.LoadScene(scene);
	}
}
