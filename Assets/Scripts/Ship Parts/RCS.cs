using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RCS : NetworkBehaviour, ITriggerTaskable, IFloatTaskable {

	public RCSFuel fuel_tank;
	public Vector3 torque;
	public float burn_time;

	private Rigidbody rb;
	private bool is_maneuvering = false;
	private bool fueled = true;

	private bool is_burning;
	private bool is_anti;


	[SyncVar(hook = "SetState")]
	public bool active;
	[SyncVar(hook = "Burn")]
	private float wait_time;

	public void TriggerTask()
	{
		Debug.Log("triggering ");
		active = !active;
	}
	public void FloatTask(float wait_time)
	{
		if(active && fueled && !is_maneuvering)
		{
			Debug.Log("float tasked");
			this.wait_time = wait_time;
		}
	}

	private void Start()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	private void SetState(bool state)
	{
		active = state;
		if(fuel_tank.Fuel != 0)
		{
			fueled = true;
		}
	}

	public void Burn(float wait_time)
	{
		is_burning = true;
		if(wait_time < 0)
		{
			is_anti = true;
		}
		if(wait_time > 0)
		{
			is_anti = false;
		}
		if(wait_time == 0)
		{
			return;
		}

		is_maneuvering = true;
		Invoke("StopBurn", burn_time);
		Invoke("AntiBurn", burn_time + Mathf.Abs(wait_time));
	}

	private void StopBurn()
	{
		is_burning = false;
	}
	private void AntiBurn()
	{
		is_burning = true;
		is_anti = !is_anti;
		Invoke("StopManeuver", burn_time);
	}
	private void StopManeuver()
	{
		Debug.Log("Done Maneuvering");
		is_burning = false;
		is_maneuvering = false;
	}

	private void FixedUpdate()
	{
		if (is_burning)
		{
			if (is_anti)
			{
				rb.AddRelativeTorque(-torque);
			}
			else
			{
				rb.AddRelativeTorque(torque);
			}
			fuel_tank.Fuel -= torque.magnitude;
			if(fuel_tank.Fuel <= 0)
			{
				fueled = false;
			}
		}
	}
}
