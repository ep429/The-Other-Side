using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 5f;
	public Transform[] spawnPoints;

	// Use this for initialization
	public void Start () {

		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	
	}
	
	// Update is called once per frame
	public void Spawn()
	{
		Debug.Log (ShiftWorld._brightWorldToggled);
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		if (Input.GetKey (KeyCode.Space) && ShiftWorld._brightWorldToggled == false) {
			GameObject spawner = Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation) as GameObject;

			spawner.transform.parent = gameObject.transform;

		}
	}
}
