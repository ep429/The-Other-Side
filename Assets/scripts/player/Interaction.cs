using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

	public Animator animator;
	private bool isIn = false;
	private Lever thisLever;
	public AudioClip leverPull;

	// Use this for initialization
	void Start () {

		thisLever = gameObject.GetComponent<Lever> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E) && isIn) {

			animator.SetTrigger ("Switch");
			thisLever.Switch();
			PlaySound ();
		}

	
	}
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Hit");
			isIn = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Hit");
			isIn = false;
		}
	}
	void PlaySound()
	{

		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = leverPull;
		audio.Play ();
	}
}
