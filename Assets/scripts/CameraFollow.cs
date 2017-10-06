using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (player != null) {
			if (player.transform.position.x >= -9.4 && player.transform.position.x <= 15)
			if (player.transform.position.y >= -13)
				transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
		}


		if (Input.GetKey (KeyCode.LeftArrow)) {

			transform.position -= new Vector3 (5, 0, 0);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {

			transform.position += new Vector3 (5, 0, 0);
		}
		else if (Input.GetKey (KeyCode.UpArrow)) {

			transform.position += new Vector3 (0, 5, 0);
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {

			transform.position -= new Vector3 (0, 5, 0);
		}
	}
}
