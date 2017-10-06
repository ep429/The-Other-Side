using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Killable playerHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector2(1f * playerHealth.health / playerHealth.maxHealth, transform.localScale.y);
	}
}
