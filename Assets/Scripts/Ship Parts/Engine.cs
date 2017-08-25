using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Engine : NetworkBehaviour {

	private Rigidbody rb;

	private List<FuelSystem> LOX;
	private List<FuelSystem> LH2;
	private int max_fuel_systems;
	private int active_fuel_systems;
	private int active_LOX;
	private int active_LH2;

	public float max_thrust;
	private float current_thrust = 0;
	private float target_thrust;

	public float thrust_increment;

	[HideInInspector]
	[SyncVar(hook = "SetThrust")]
	public float level;

	[SyncVar]
	public bool ignited = false;

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
		LOX = new List<FuelSystem>();
		LH2 = new List<FuelSystem>();
	}

	private void Start()
	{
		foreach (FuelSystem fuel in GetComponentsInChildren<FuelSystem>())
		{
			if (fuel.is_LOX)
			{
				LOX.Add(fuel);
			}
			else
			{
				LH2.Add(fuel);
			}
		}

		max_fuel_systems = LH2.Count > LOX.Count ? LOX.Count : LH2.Count;

		CheckFuelSystems();
	}

	public void CheckFuelSystems()
	{
		active_LH2 = 0;
		active_LOX = 0;

		foreach (FuelSystem fuel in LH2)
		{
			if(fuel.valve_open && fuel.pump_on)
			{
				active_LH2 += 1;
			}
		}
		foreach (FuelSystem fuel in LOX)
		{
			if (fuel.valve_open && fuel.pump_on)
			{
				active_LOX += 1;
			}
		}

		active_fuel_systems = active_LH2> active_LOX? active_LOX: active_LH2;
	}

	private void FixedUpdate()
	{
		if (ignited)
		{
			if (Mathf.Abs(current_thrust - target_thrust) <= thrust_increment)
			{
				current_thrust = target_thrust;
			}
			else
			{
				if (current_thrust > target_thrust)
				{
					current_thrust -= thrust_increment;
				}
				else
				{
					current_thrust += thrust_increment;
				}
			}

			float limited_thrust = max_thrust * ((float)active_fuel_systems / max_fuel_systems);
			if (current_thrust >= limited_thrust)
			{
				current_thrust = limited_thrust;
			}

			rb.AddForce(Vector3.up * current_thrust);

			if (Mathf.Approximately(current_thrust, 0))
			{
				ignited = false;
			}
		}
	}

	public void SetThrust(float new_level)
	{
		level = new_level;
		target_thrust = max_thrust * new_level;
	}

}
