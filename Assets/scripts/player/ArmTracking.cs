using UnityEngine;
using System.Collections;

public class ArmTracking : MonoBehaviour {

	public GameObject player;

	private Vector2 _currentDirection;
	private Vector2 _currentMousePos;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		faceMousePosition ();
	}

	public void faceMousePosition() {
		_currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_currentMousePos.y - transform.position.y, _currentMousePos.x - transform.position.x) * Mathf.Rad2Deg);
		if (player.transform.localScale.x == -1) {
			transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.y - _currentMousePos.y, transform.position.x -  _currentMousePos.x) * Mathf.Rad2Deg);
		}
	}
}
