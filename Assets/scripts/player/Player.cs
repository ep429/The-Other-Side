using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : Killable {

	public float moveSpeed;
	public float jumpSpeed;
	public Transform groundCheckTopRight; // Top right of box used for checking if the player is touching the ground
	public Transform groundCheckBottomLeft; // Bottom left of the box
	public LayerMask[] groundCheckLayers; // Layers that count as ground for the player
	public AudioClip[] audioClip;
	public GameObject reloadParticleEffects;

	public Vector3 startPos;

	public ResourceManager playerResourceManager;
	private Rigidbody2D _myRigidbody;

	// if the player falls below this, they lose health
	public float minYPos = - 15;

	// if player reaches these limits, they can't move in that direction any more
	public float minXPos = -19.5f;
	public float maxXPos = 25;

	// Use this for initialization	
	new void Start () {
		base.Start ();
		_myRigidbody = GetComponent<Rigidbody2D> ();

		playerResourceManager = GetComponent<ResourceManager> ();
		startPos = new Vector3 (-2.347f, 0, 0);
	}

	// Update is called once per frame
	new void Update () {
		base.Update ();
		float newXVel = 0;

		// Vertical movement controls
		if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.Space)) {
			if (IsOnGround ()) {
				_myRigidbody.velocity = new Vector2 (_myRigidbody.velocity.x, jumpSpeed);
				PlaySound (0);
			}
		} else if (Input.GetKeyDown(KeyCode.S)) {
			// TODO: crouching
		}


		// Horizontal movement controls.

		if (Input.GetKey (KeyCode.D) && _myRigidbody.position.x <= maxXPos && !Input.GetKey(KeyCode.Space)){
			newXVel = 1;
		} else if (Input.GetKey (KeyCode.A) && _myRigidbody.position.x >= minXPos && !Input.GetKey(KeyCode.Space)) {
			newXVel = -1;
		}


		// Used by animator to determine if run or jump animations should play
		animator.SetFloat ("speed", Mathf.Abs(newXVel * moveSpeed));
		animator.SetFloat ("vspeed", Mathf.Abs (_myRigidbody.velocity.y));

		_myRigidbody.velocity = new Vector2(newXVel * moveSpeed, _myRigidbody.velocity.y);
		/*if (IsOnGround()) {
			_myRigidbody.AddForce (new Vector2 (newXVel * moveSpeed, _myRigidbody.velocity.y));
		}*/

		// Flipping character sprite handling
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (mousePos.x > transform.position.x) {
			transform.localScale = new Vector2(1, 1);
		} else if (mousePos.x < transform.position.x) {
			transform.localScale = new Vector2(-1, 1);
		}
		//Where the charging is called
		if (Input.GetKey (KeyCode.Space)) {
			reloadParticleEffects.SetActive (true);
			StartCoroutine (playerResourceManager.StartCharge ());
		} else {
			reloadParticleEffects.SetActive (false);
		}
		//plays the sound effect for the battery charging
		//had to be GetKeyDown otherwise if would interupt the sound effect
		if (Input.GetKeyDown (KeyCode.Space)) {
			PlaySound (1);
		}

		if (Input.GetKeyUp(KeyCode.Space)) {
			StopCoroutine (playerResourceManager.StartCharge ());
			StopSound ();
		}

		// Checks if player falls out of frame
		if (_myRigidbody.transform.position.y <= minYPos) {
			Damage (25);
			transform.position = startPos;
		}

		if (health <= 0f)
			SceneManager.LoadScene ("Lose");

		if (Input.GetKeyDown (KeyCode.X)) {

			SceneManager.LoadScene ("Sample_Puzzle");
		}
		
	}

	// Check if player is colliding with any objects that belong to the groundCheckLayers layer masks
	private bool IsOnGround() {
		foreach (int groundCheckLayer in groundCheckLayers) {
			if (Physics2D.OverlapArea (groundCheckTopRight.position, groundCheckBottomLeft.position, groundCheckLayer)) {
				return true;
			}
		}
		return false;
	}


	void PlaySound(int clip)
	{

		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = audioClip [clip];
		audio.Play ();
	}
	void StopSound()
	{
		AudioSource audio = GetComponent<AudioSource>();
		audio.Stop ();
	}
		
}
