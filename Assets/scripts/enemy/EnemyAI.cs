using UnityEngine;
using System.Collections;

public class EnemyAI : Killable {

	private enum STATE {WANDER, CHASE, ATTACK, DEAD};


	public float wanderSpeed;
	public float chaseSpeed;
	public float minWander;
	public float maxWander;
	public LayerMask attackPlayer;
	public float sightDistance;
	public float strikeDistance;
	public float knockback;


	private STATE _currentState;
	private float _currentWanderTime;
	private GameObject _currentTarget;
	private Vector2 _currentDirection;
	public static Rigidbody2D _myRigidbody2D;
	// Use this for initialization
	new void Start () {
		_myRigidbody2D = GetComponent<Rigidbody2D> ();
		EnterStateWander ();
	
	}
	
	// Update is called once per frame
	new void Update () {

		switch (_currentState) {
		case STATE.DEAD:
			break;
		case STATE.WANDER:
			UpdateWander ();
			break;
		case STATE.CHASE:
			UpdateChase ();
			break;
		case STATE.ATTACK:
			UpdateAttack ();
			break;
		}
	
	}

	//Enter the wander state
	private void EnterStateWander()
	{
		_currentState = STATE.WANDER;
		_currentDirection = new Vector2 (Random.Range (-1f, 1f), 0);
		_currentWanderTime = Random.Range (minWander, maxWander);
	}
	//Update position for wander state and flip character depending on position
	private void UpdateWander()
	{

		//Debug.Log (_currentDirection);
		_myRigidbody2D.velocity = _currentDirection * wanderSpeed;
		animator.SetFloat ("speed", wanderSpeed);
		_currentWanderTime -= Time.deltaTime;
		if (_currentDirection.x < 0f) {
			transform.localScale = new Vector2 (1, 1);
			transform.position += Vector3.left * Time.deltaTime;
		}
		else if (_currentDirection.x > 0f)
		{
			transform.localScale = new Vector2(-1, 1);
			transform.position += Vector3.right * Time.deltaTime;
		}

		if (_currentWanderTime <= 0f)
			EnterStateWander ();
		RaycastHit2D hit = Physics2D.Raycast (transform.position, _currentDirection, sightDistance, attackPlayer.value);
//		Debug.DrawRay (transform.position, sightDistance, Color.green);
		if (hit.collider != null) {
			Debug.Log("Hit");
			EnterStateChase (hit.collider.gameObject);
		}
	}

	//Enter the chase state, will follow player depending on sight
	private void EnterStateChase(GameObject target)
	{
		_currentState = STATE.CHASE;
		_currentTarget = target;
		_currentDirection = (target.transform.position - transform.position).normalized;
	}

	//Updates the position of chase depending on player position and sight
	private void UpdateChase()
	{
		Debug.Log ("CHASE");
		Vector2 targetDirection = (_currentTarget.transform.position - transform.position).normalized;
		_currentDirection = Vector3.RotateTowards (_currentDirection.normalized, targetDirection, 0f, 0f).normalized;

		if (_currentDirection.x <= 0f) {
			transform.localScale = new Vector2 (1, 1);
			animator.transform.position += Vector3.left * Time.deltaTime * chaseSpeed;
		}
		else if (_currentDirection.x >= 0f)
		{
			transform.localScale = new Vector2(-1, 1);
			animator.transform.position += Vector3.right * Time.deltaTime * chaseSpeed;
		}
		animator.SetFloat ("speed", Mathf.Abs(chaseSpeed));
		float targetDistance = Vector3.Distance (_currentTarget.transform.position, transform.position);
		if (targetDistance <= strikeDistance) {
			EnterStateAttack ();
		} else if (targetDistance > sightDistance || Vector2.Angle (_currentDirection, targetDirection) > 30f) {
			_currentState = STATE.WANDER;
		}
	}

	//Enter the attack state, will play animation
	private void EnterStateAttack()
	{
		_currentState = STATE.ATTACK;
		_myRigidbody2D.velocity = Vector2.zero;
		animator.SetTrigger ("attack");
	}

	private void UpdateAttack()
	{}

	//Do the attack if player is close enough
	public void DoAttack()
	{
		Debug.Log ("Attacking");
		RaycastHit2D hit = Physics2D.Raycast (new Vector2(transform.position.x, transform.position.y + 0.5f), _currentDirection, strikeDistance, attackPlayer.value);
		if (hit.collider != null) {
			if (hit.collider.gameObject.GetComponent<Player> () != null) {
				hit.collider.gameObject.GetComponent<Player> ().Damage (25);
				hit.collider.gameObject.GetComponent<Player> ().Knockback (knockback, _currentDirection, hit.rigidbody);
				/*if (_currentDirection.x <= 0f) {
					hit.rigidbody.AddForce (-transform.right * knockback);
				} else if (_currentDirection.x >= 0f) {
					hit.rigidbody.AddForce (transform.right * knockback);
				}*/

			}
		}
				
	}
	//When attack is over exit that state and go into wander
	public void AttackOver()
	{
		EnterStateChase(_currentTarget);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "wall")
		{
			//Debug.Log ("Wall");

			if (_currentState == STATE.WANDER)
			{
				_myRigidbody2D.velocity = Vector3.zero;
				if (_currentDirection.x < 0f) {
					_currentDirection.x = 1f;
				}
				else if (_currentDirection.x > 0f)
				{
					_currentDirection.x = -1f;
				}
			}
		}
	}

	public override void Kill() {
		_currentState = STATE.DEAD;
		_myRigidbody2D.velocity = Vector2.zero;
		animator.SetTrigger ("death");
	}

	public void KillOver() {
		GameObject corpse = (GameObject) Resources.Load ("prefabs/Enemy_1_Corpse", typeof(GameObject));
		corpse = Instantiate (corpse, transform.position, transform.rotation, transform.parent) as GameObject;
		Destroy (this.gameObject);
	}
}
