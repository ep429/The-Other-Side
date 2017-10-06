using UnityEngine;
using System.Collections;

public class AttackListener : MonoBehaviour {

	public EnemyAI controller;
	// Use this for initialization
	public void AttackTrigger()
	{
		controller.DoAttack();
	}

	public void AttackOver()
	{
		controller.AttackOver ();
	}
}
