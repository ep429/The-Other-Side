using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSprite : ShiftWorld {

	public GameObject[] brightLever;
	public GameObject[] darkLever;
	public int leverAmount;
	// Use this for initialization
	void Start () {
		_brightWorldToggled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (_brightWorldToggled) {
			for (int i = 0; i < brightLever.Length; i++) {
				//Sprite
//				Debug.Log(i);
				brightLever [i].GetComponent<SpriteRenderer> ().enabled = true;
				brightLever [i].GetComponent<BoxCollider2D> ().enabled = true;
				for (int j = 0; j < darkLever.Length; j++) {

					if (darkLever [j] != null) {
						darkLever [j].GetComponent<SpriteRenderer> ().enabled = false;
						darkLever [j].GetComponent<BoxCollider2D> ().enabled = false;
					}
				}

				//Box Collider 2D


			}
		} else {
			for (int i = 0; i < darkLever.Length; i++) {
				//Sprites

				if (darkLever [i] != null) {
					darkLever [i].GetComponent<SpriteRenderer> ().enabled = true;
					darkLever [i].GetComponent<BoxCollider2D> ().enabled = true;
				}

				for (int j = 0; j < brightLever.Length; j++) {
					brightLever [j].GetComponent<SpriteRenderer> ().enabled = false;
					brightLever [j].GetComponent<BoxCollider2D> ().enabled = false;
				}

				//Box Collider 2D

			}
		}
		
	}
}
