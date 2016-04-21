﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {

	public string scene; // this is the level they go to when getting to exit sign 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D target) { 
		if (target.gameObject.tag == "Player") {
			Destroy(target.gameObject);
			SceneManager.LoadScene(scene);
		}
	}
}
