using UnityEngine;
using System.Collections;

public class LookForward : MonoBehaviour {

	// where we want to begin looking and where sight ends
	public Transform sightStart, sightEnd;
	private bool collision = false; 
	public bool needsCollision = true;     // on a platform, checking whether there isn't a collision at all 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		collision = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Solid"));

		Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

		if (collision == needsCollision) { 
			this.transform.localScale = new Vector3((transform.localScale.x == 1) ? -1: 1, 1, 1);
		}
	}
}
