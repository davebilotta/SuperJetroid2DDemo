using UnityEngine;
using System.Collections;

public class OxygenMeter : MonoBehaviour {
	 
	public float air = 10;         // amount of air left
	public float maxAir = 10;      // max air player can have
	public float airBurnRate = 1f; // burndown rate for air

	public Texture2D bgTexture;                      // background of bar
	public Texture2D airBarTexture;                  // foreground of bar
	public int iconWidth = 32;                       // don't subtract from icon bar more than width 
	public Vector2 airOffset = new Vector2 (10,10);  // offset for where to place this on screen

	private Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
	}

	void OnGUI() { 
		var percent = Mathf.Clamp01( air / maxAir);

		if (!player) percent = 0;

		DrawMeter(airOffset.x, airOffset.y,airBarTexture, bgTexture, percent);
	}

	void DrawMeter(float x, float y, Texture2D foreground, Texture2D background, float percent) { 
		var bgW = background.width;
		var bgH = background.height;

		GUI.DrawTexture(new Rect(x,y,bgW,bgH),background);

		// alter foreground based on percentage 

		var fgWidth = ((bgW - iconWidth) * percent) + iconWidth;
		GUI.BeginGroup(new Rect(x,y,fgWidth,bgH),foreground);
		GUI.DrawTexture(new Rect(0,0,bgW,bgH),foreground);
		GUI.EndGroup();
	}
	
	// Update is called once per frame
	void Update () {
		if (!player) return;

		if (air > 0) { 
			air -= Time.deltaTime * airBurnRate;
		}
		else { 
			Explode script = player.GetComponent<Explode>(); // get reference to Explode script on player 
			script.OnExplode(); 
		}
	}
}
