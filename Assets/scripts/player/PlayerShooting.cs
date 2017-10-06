using UnityEngine;
using System.Collections;


public class PlayerShooting : MonoBehaviour {


	public GameObject bullet;
	public GameObject shootPoint;
	public float fireTime;
	public float bulletSpeed;
	public GameObject player;
	public float knockback;

	private float _timeToFire;
	private Vector3 _originalCamPosition;
	private Animator _animator;
	private AudioSource _source;
	private ResourceManager _resourceManager;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		_source = GetComponent<AudioSource> ();
		_resourceManager = player.GetComponent<ResourceManager> ();

		//AudioSource audio = GetComponent<AudioSource>();



	}

	// Update is called once per frame
	void Update () {
		_timeToFire -= Time.deltaTime;

		if (Input.GetMouseButtonDown (0) && _timeToFire <= 0f && _resourceManager.HasEnoughBulletCharge() && !Input.GetKey(KeyCode.Space)) {
			_timeToFire = fireTime;
			FireBullet ();
			_resourceManager.FireBullet ();
			PlaySound();



		}
	}

	public void FireBullet() {
		GameObject g0 = Instantiate (bullet, shootPoint.transform.position, transform.rotation) as GameObject;
		bool facingLeft = player.transform.localScale.x == -1;
		g0.GetComponent<Rigidbody2D> ().velocity = transform.rotation * (!facingLeft ? Vector2.right : Vector2.left) * bulletSpeed;
		g0.transform.rotation = transform.rotation;


		if (facingLeft) {
			player.transform.position = new Vector2 (player.transform.position.x + knockback, player.transform.position.y);
		} else {
			player.transform.position = new Vector2 (player.transform.position.x - knockback, player.transform.position.y);
		}
	}

	void PlaySound()
	{
		
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play ();
	}
}
