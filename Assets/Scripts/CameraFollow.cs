using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;

	private Transform _t;   // _t = cached

	void Awake() { 
		// gets called before Start
		Camera camera = GetComponent<Camera>();
		// 100f = pixel ratio
		camera.orthographicSize = ((Screen.height / 2.0f) / 100f);


	}
	// Use this for initialization
	void Start () {
		_t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		// If Player still exists, follow
		// if (_t) would also work
		if (GameObject.Find("Player")) {
			transform.position = new Vector3(_t.position.x, _t.position.y, transform.position.z);
		}
		else { 
			Debug.Log("Target no longer existss");
		}
	}


}
