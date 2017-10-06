using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public AudioClip impactSound;
	public int damage;

	private bool _triggered = false;
	private Rigidbody2D _rigidBody;
	private Animator _animator;
	private AudioSource _audioSource;

	void OnTriggerEnter2D(Collider2D c) {
		if (_triggered) {
			return;
		}
		_triggered = true;
		Transform obj = c.transform;
		Vector2 direction = -_rigidBody.velocity;
		while (obj != null) {
			if (obj.gameObject.GetComponent<Killable> () != null) {
				obj.gameObject.GetComponent<Killable> ().Damage (damage);
				//Knockback enemy
				obj.gameObject.GetComponent<EnemyAI> ().Knockback (1000, obj.localScale, EnemyAI._myRigidbody2D);
				break;
			}

			obj = obj.transform.parent;
		}

		damage = 0;

		if (_rigidBody != null) _rigidBody.velocity = Vector2.zero;
		if (_animator != null) _animator.SetTrigger ("kill");
		if (_audioSource != null) _audioSource.PlayOneShot (impactSound);
	}

	void DestroyThis() {
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody2D> ();
		_animator = GetComponent<Animator> ();
		_audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}
}
