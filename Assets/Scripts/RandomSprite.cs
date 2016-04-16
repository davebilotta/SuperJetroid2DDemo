using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {

	public Sprite[] sprites;         // Will contain all sprites we load dynamically from Resources folder
	public string resourceName;      // Name of file we use to pull texture out of folder
	public int currentSprite = -1;   // ID in sprite array that if set will override Random function.

	// Use this for initialization
	void Start () {
		if (resourceName != "") {
			sprites = Resources.LoadAll<Sprite>(resourceName);
	
			if (currentSprite == -1) { 
				currentSprite = Random.Range(0,sprites.Length);
			}
			else if (currentSprite > sprites.Length) {
				currentSprite = sprites.Length - 1;	
			}

			GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
		} // end resourceName if
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
