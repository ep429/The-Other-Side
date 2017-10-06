using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Used by any actor or object that has a limited number of hp.
public class Killable : MonoBehaviour {

	public int maxHealth; // Maximum health the actor may have
	public int health; // Current health the actor has
	public SpriteRenderer[] spriteRenderers; // All of the sprite renderers used by the actor and its children. Used when getting hit.
	public Animator animator; // Animator for the actor
	public AudioClip[] damageSounds;
	public string levelName;

	private Shader _shaderGUItext; // Used for making the actor flash white
	private Shader _shaderSpritesDefault; // Used for making the actor flash white



	// Use this for initialization
	protected void Start () {

	}

	protected void Update() {

	

	}

	// Reduce the actor's health by amt, & flash white
	virtual public void Damage(int amt) {
		health -= amt;
		PlaySound (0);
		// Trigger the 'damaged' animation (object shake, usually) if it exists
		if (animator != null && animator) {
			animator.SetTrigger ("damaged");
		}
		HighlightWhite ();
		if (health <= 0) {
			PlaySound (1);
			Kill ();
		}
	}

	virtual public void Knockback(float strength, Vector2 currentDirection, Rigidbody2D rigidbody)
	{
		if (currentDirection.x <= 0f) {
			rigidbody.AddForce (-transform.right * strength);
		} else if (currentDirection.x >= 0f) {
			rigidbody.AddForce (transform.right * strength);
		}
	}
		

	// Turn the sprite(s) white
	virtual protected void HighlightWhite() {
		_shaderGUItext = Shader.Find ("GUI/Text Shader");
		_shaderSpritesDefault = Shader.Find ("Sprites/Default");
		foreach (SpriteRenderer sr in spriteRenderers) {
			sr.material.shader = _shaderGUItext;
			sr.color = Color.white;
		}
		Invoke ("UnHighlight", 0.1f);
	}

	// Turn the sprite(s) back to its original color
	virtual protected void UnHighlight() {
		foreach (SpriteRenderer sr in spriteRenderers) {
			sr.material.shader = _shaderSpritesDefault;
			sr.color = Color.white;
		}
	}


	virtual public void Kill() {
		Debug.Log ("YOU DIED");
		Destroy (this.gameObject);
		SceneManager.LoadScene (levelName);
	}
	void PlaySound(int clip)
	{

		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = damageSounds [clip];
		audio.Play ();
	}
}
