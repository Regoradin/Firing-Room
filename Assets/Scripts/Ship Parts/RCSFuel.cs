using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCSFuel : MonoBehaviour {

	public float max_fuel;
	private float fuel;
	public float Fuel
	{
		get
		{
			return fuel;
		}
		set
		{
			fuel = value;
			fuel = fuel <= 0 ? 0 : fuel;
		}
	}

	void Awake()
	{
		fuel = max_fuel;
	}

}
