using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public List<GameObject> parallaxObjects; // List of all objects to appy parallax to

	public float maxParallax; // Highest amount to apply parallax. 1 means the object moves with the camera.
	public float minParallax; // Smallest amount to apply parallax. 0 means the object doesn't move at all when the camera moves.

	private List<SortingLayer> _sortingLayers;
	private Vector2 _lastPos;


	// Use this for initialization
	void Start () {
		_lastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPos = transform.position;
		Vector2 posDif = new Vector2 (currentPos.x - _lastPos.x, currentPos.y - _lastPos.y);
		_lastPos = currentPos;
		foreach (GameObject obj in parallaxObjects) {
			float x = obj.transform.position.x;
			float y = obj.transform.position.y;
			float z = obj.transform.position.z;
			obj.transform.position = new Vector3 (x + posDif.x * Mathf.Max(minParallax, Mathf.Min(z, maxParallax)), 
													y + posDif.y * Mathf.Max(minParallax, Mathf.Min(z, maxParallax)),
													z);
		}
	}
}
