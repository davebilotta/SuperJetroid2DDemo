using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public AudioClip pickupSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target) { 
		// target = target of object that set off trigger
	
		if (target.gameObject.tag == "Player") {
			if (pickupSound) {
				AudioSource.PlayClipAtPoint(pickupSound,transform.position);
			}
			Destroy(gameObject);
		}
	}
}
