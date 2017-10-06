using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{

	public float MaxCharge;
	public float MinCharge;

	public float CurrentCharge;

	public float BulletChargeCost;
	public float UniverseChargeCost;

	void Start()
	{

		MaxCharge = 100f;
		MinCharge = 0f;

		CurrentCharge = 50.0f;

		BulletChargeCost = 10.0f;
		UniverseChargeCost = 20.0f;
	}

	public IEnumerator StartCharge()
	{
		if (CurrentCharge < MaxCharge) 
		{
			Debug.Log ("Current charge is " + CurrentCharge);
			CurrentCharge += 0.5f;
			yield return new WaitForSeconds (3);
		}

	}

	public void FireBullet()
	{
		CurrentCharge -= BulletChargeCost;
	}

	public void SwitchUniverse()
	{
		CurrentCharge -= UniverseChargeCost;
	}

	public bool HasEnoughUniverseCharge()
	{
		return CurrentCharge >= UniverseChargeCost;
	}

	public bool HasEnoughBulletCharge()
	{
		return CurrentCharge >= BulletChargeCost;
	}
}

