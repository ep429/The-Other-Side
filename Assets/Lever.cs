using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

	public int id
	{
		get;
		set;
	}

	public bool isEngaged
	{
		get;
		set;
	}

	void Start ()
	{
		isEngaged = false;
	}

	public void Switch()
	{
		isEngaged = !isEngaged;
	}
} 

