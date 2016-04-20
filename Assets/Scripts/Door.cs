using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public const int IDLE = 0;
	public const int OPENING = 1;
	public const int OPEN = 2;
	public const int CLOSING = 3;

	private float closeDelay = 0.5f;
	private int state = IDLE;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnOpenStart() { 
		state = OPENING;
	}

	void OnOpenEnd() { 
		state = OPEN;

	}

	void OnCloseStart() { 
		state = CLOSING;
	}

	void OnCloseEnd() {
		state = IDLE;
	}

	void DisableCollider2D() {
		GetComponent<Collider2D>().enabled = false;
	}

	void EnableCollider2D() { 
		GetComponent<Collider2D>().enabled = true;
	}

	public void Open() {
		animator.SetInteger("AnimState",1);
	}

	public void Close() {
		// want door to have a delay before closing 

		StartCoroutine(CloseNow());

		

	}

	private IEnumerator CloseNow() {
		yield return new WaitForSeconds(closeDelay); // anything below this line gets called once delay takes place.
		animator.SetInteger("AnimState",2);
	}

}
