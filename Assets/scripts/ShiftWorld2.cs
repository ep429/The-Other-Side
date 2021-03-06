using UnityEngine;
using System.Collections;

public class ShiftWorld2 : MonoBehaviour {

	public GameObject brightWorld;
	public GameObject darkWorld;

	private bool _brightWorldToggled = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			ToggleWorld ();

		}
	}

	void ToggleWorld() {
		if (_brightWorldToggled) {
			darkWorld.SetActive (true);
			brightWorld.SetActive (false);
			_brightWorldToggled = false;
		} else {
			darkWorld.SetActive (false);
			brightWorld.SetActive (true);
			_brightWorldToggled = true;
		}
	}
}
