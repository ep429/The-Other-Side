using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideText : MonoBehaviour {

	private bool show = false;
	public string guide;
	private GUIStyle gui = new GUIStyle();
	public Font font;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		pos = Camera.main.WorldToScreenPoint (transform.position);
		
	}

	void OnTriggerEnter2D()
	{
		show = true;
	}

	void OnTriggerExit2D()
	{
		show = false;
	}

	void OnGUI()
	{
		if (show) {
			GUI.contentColor = Color.black;
			GUI.skin.font = font;
			gui.fontSize = 20;
			GUI.Label (new Rect (pos.x-30, pos.y-100, 100, 100), guide, gui);
		}
	}
}
