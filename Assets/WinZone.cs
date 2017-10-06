using System;
using UnityEngine;
public class WinZone : MonoBehaviour
{

	public ShiftWorld shiftWorldScript;
	public Player player;

	public bool ShiftAllowed = true;

	void Start(){

		shiftWorldScript = player.GetComponent<ShiftWorld> ();
	}

	void OnTriggerEnter2D(Collider2D other){

		Debug.Log ("COLLIDER ENTER");
		ShiftAllowed = false;
	}

	void OnTriggerExit2D(Collider2D other){

		Debug.Log ("COLLIDER EXIT");
		ShiftAllowed = true;
	}
}

