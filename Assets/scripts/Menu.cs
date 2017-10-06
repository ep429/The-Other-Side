using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameObject controlsPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowControls() {
		controlsPanel.SetActive (true);
	}

	public void HideControls() {
		controlsPanel.SetActive (false);
	}

	public void Quit() {
		Debug.Log ("Quitting");
		Application.Quit ();
	}
}
