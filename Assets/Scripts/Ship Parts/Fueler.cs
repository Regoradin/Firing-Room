using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Fueler : NetworkBehaviour, IBoolTaskable {

	public FuelSystem fuel_system;

	[SyncVar]
	public bool attached = true;
	[SyncVar]
	public bool fueling = false;

	public float flowrate = 1;

	public void BoolTask(bool b)
	{
		if (b)
		{
			if (attached)
			{
				attached = false;
			}
			if (!attached && fuel_system.GetComponent<Rigidbody>().velocity.sqrMagnitude == 0)
			{
				//can only be reattached if the ship isn't moving
				attached = true;
			}
		}
		else
		{
			fueling = !fueling;
		}
	}

	private void Update()
	{
		if(attached && fueling)
		{
			fuel_system.Fuel += flowrate * Time.deltaTime;
		}
	}


}
