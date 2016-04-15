using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelloWorld : MonoBehaviour {

	public List<string> list = new List<string>();
	public float speed = 2f;

	// Use this for initialization
	void Start () {
		/*string name = "Dave Bilotta";
		int age = 38;
		float speed = 4.3f;
		bool likesGames = true;

		var stringArray = new string[2];
		stringArray[0] = "Hello";
		stringArray[1] = "World";

		var phrase = stringArray[0] + " " + stringArray[1];

		Debug.Log(phrase);

		print("Your name is: " + name);

		print(list[0] + " " + list[1]); */
	}
	
	// Update is called once per frame
	void Update () {

		// Translate moves an opject to a position
		transform.Translate(new Vector3(speed,0,transform.position.z) * Time.deltaTime);
	

	}
}
