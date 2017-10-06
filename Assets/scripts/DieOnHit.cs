using UnityEngine;
using System.Collections;

public class DieOnHit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c) {
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
