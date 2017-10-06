using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinObject : MonoBehaviour
{
	public string sceneAdvance;


	void Awake(){

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			// player wins!
			SceneManager.LoadScene (sceneAdvance);
		}
	}
}

