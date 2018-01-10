using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RCS : NetworkBehaviour, ITriggerTaskable {

	public Vector3 rotation_speed;
	public RCSFuel fuel_tank;

	[HideInInspector]
	public bool fueled = true;

	private RotationController rot_controller;

	[SyncVar(hook = "SetState")]
	public bool active;
	public void TriggerTask()
	{
		active = !active;
	}

	private void Start()
	{
		rot_controller = GetComponentInParent<RotationController>();
	}

	private void SetState(bool state)
	{
		active = state;
		if(fuel_tank.Fuel != 0)
		{
			fueled = true;
		}
		rot_controller.CheckActiveRCS();
	}

	public void ConsumeFuel(Vector3 rotation)
	{
		//checks to see if this RCS was used at all
		rotation.Scale(rotation_speed);
		if(rotation != Vector3.zero)
		{
			fuel_tank.Fuel -= rotation_speed.magnitude;
			if(fuel_tank.Fuel == 0)
			{
				fueled = false;
			}
		}
	}

}
