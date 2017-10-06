using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour {

	public GameObject lever;
	private Lever thisLever;
	public GameObject gate;
	public Animator gateAnim;
	// Use this for initialization
	void Start () {
		thisLever = lever.GetComponent<Lever> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (thisLever.isEngaged) {
			gateAnim.SetBool ("Open", true);
			gate.GetComponent<BoxCollider2D>().enabled = false;
		} else {
			gateAnim.SetBool ("Open", false);
			gate.GetComponent<BoxCollider2D> ().enabled = true;
		}
			
			
		
	}
}
