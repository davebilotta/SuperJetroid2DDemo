using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour {

	public BodyPart bodyPart;
	public int totalParts = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target) { 
		if (target.gameObject.tag == "Deadly") {
			OnExplode();
		}
	}

	void OnCollisionEnter2D(Collision2D target) { 
		if (target.gameObject.tag == "Deadly") {
			OnExplode();
		}
	}

	public void OnExplode() { 

		Destroy(gameObject);

		var t = transform;

		// throw body parts everywhere
		for (int i = 0; i < totalParts; i++) {
			// move body part outside of player's area 
			t.TransformPoint(0, -100, 0);

			// cloning body part 
			// Quaternion.identity: rotation = 0?
			BodyPart clone = Instantiate(bodyPart,t.position,Quaternion.identity) as BodyPart;
			// apply a random force to get it to go off in different directions 
			// Vector3.right = shorthand for Vector3(1,0,0)

			// random left and right
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-50,50));

			// random up
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100,400));

		}

		GameObject go = new GameObject("ClickToContinue");
		ClickToContinue script = go.AddComponent<ClickToContinue>();
		// formerly Application.loadedLevelName; 
		script.scene = SceneManager.GetActiveScene().name;
		go.AddComponent<DisplayRestartText>();

	}
}
