using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

	public GameObject Lever1;
	public GameObject Lever2;
	public GameObject Lever3;

	public GameObject gate;
	public Animator animate;

	public List<Lever> levers;

	void Start  ()
	{
		levers.Add (Lever1.GetComponent<Lever> ());
		levers.Add (Lever2.GetComponent<Lever> ());
		levers.Add (Lever3.GetComponent<Lever> ());

	}

	void Update ()
	{
		if (levers [0].isEngaged && levers[1].isEngaged && levers[2].isEngaged) {
			Debug.Log ("DOOR UNLOCKED");
			animate.SetBool ("Open", true);
			gate.GetComponent<BoxCollider2D>().enabled = false;
		}

	}

}

