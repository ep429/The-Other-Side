using UnityEngine;
using System.Collections;

public class ChargeBar : MonoBehaviour {

	public ResourceManager playerCharge;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector2(1f * playerCharge.CurrentCharge / playerCharge.MaxCharge, transform.localScale.y);
	}
}
