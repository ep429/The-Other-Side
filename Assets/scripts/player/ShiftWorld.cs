using UnityEngine;
using System.Collections;

public class ShiftWorld : MonoBehaviour {

	public GameObject brightWorld;
	public GameObject darkWorld;
	public AudioClip shiftWorld;

	public static bool _brightWorldToggled = true;
	private ResourceManager _resourceManager;
	public GameObject _player;
	public GameObject _winObject;
	public GameObject _winZone;
	public WinZone _winZoneScript;

	// below are used to check that player cannot explain immediate win bug
	public float minX;
	public float minY;
	public float maxX;
	public float maxY;

	// Use this for initialization
	void Start () {
		
		_resourceManager = GetComponent<ResourceManager> ();

		minX = -3.341581f;
		minY = -2.978981f;
		maxX = -1.341581f;
		maxY = -0.978981f;

		_winZoneScript = _winZone.GetComponent<WinZone> ();
	}


	
	// Update is called once per frame
	void Update () {

		Vector3 playerPos = _player.transform.position;

		if (!(playerPos.x < maxX && playerPos.x > minX && playerPos.y < maxY && playerPos.y > minY)) {
			if (Input.GetKeyDown (KeyCode.LeftShift) && _resourceManager.HasEnoughUniverseCharge ()) {
				ToggleWorld ();
				_resourceManager.SwitchUniverse ();
				PlaySound ();
			}
		}
	}

	void ToggleWorld() {
		if (_winZoneScript.ShiftAllowed) {
			if (_brightWorldToggled) {
				darkWorld.SetActive (true);
				brightWorld.SetActive (false);
				_brightWorldToggled = false;
			} else {
				darkWorld.SetActive (false);
				brightWorld.SetActive (true);
				_brightWorldToggled = true;
			}
		}
	}

	void PlaySound()
	{

		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = shiftWorld;
		audio.Play ();
	}
}
