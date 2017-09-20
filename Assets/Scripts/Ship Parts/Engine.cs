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
	private List<FuelSystem> active_LOX;
	private List<FuelSystem> active_LH2;
	public int LOX_to_LH2_ratio = 1;

	public float max_thrust;
	private float current_thrust = 0;
	public float Current_thrust
	{
		get
		{
			return current_thrust;
		}
	}
	private float target_thrust;

	public float thrust_increment;

	private float pooled = 0;   //currently this value is used for both the radius and the force. Tweaking and experimentation will be required.
	public float pooled_force_modifier;
	public Vector3 engine_offset; //currently is just the position, but can eventually be set to have torques and stuff

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
		active_LOX = new List<FuelSystem>();
		active_LH2 = new List<FuelSystem>();
	}

	private void Start()
	{
		Debug.Log("Starting Engine");
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

	private bool is_quitting = false;
	private void OnApplicationQuit()
	{
		is_quitting = true;
	}
	private void OnDestroy()
	{
		StagedEngine staged_engine = gameObject.AddComponent<StagedEngine>();

		staged_engine.rb = rb;
		staged_engine.current_thrust = current_thrust;
		staged_engine.engine_offset = engine_offset;
		//This next bit may very well fail if a bit of fuel is destroyed before OnDestroy is called... but that shouldn't happen b/c things are actually destroyed last
		float LOX = 0;
		float LH2 = 0;
		foreach(FuelSystem fuel in active_LOX)
		{
			LOX += fuel.Fuel;
		}
		LOX /= LOX_to_LH2_ratio;
		foreach(FuelSystem fuel in active_LH2)
		{
			LH2 += fuel.Fuel;
		}
		staged_engine.fuel = LOX > LH2 ? LH2 : LOX;
	}

	public void CheckFuelSystems()
	{
		active_LH2.Clear();
		active_LOX.Clear();

		foreach (FuelSystem fuel in LH2)
		{
			if(fuel.valve_open && fuel.pump_on && fuel.Fuel > 0)
			{
				active_LH2.Add(fuel);
			}
		}
		foreach (FuelSystem fuel in LOX)
		{
			if (fuel.valve_open && fuel.pump_on && fuel.Fuel > 0)
			{
				active_LOX.Add(fuel);
			}
		}

		active_fuel_systems = active_LH2.Count > active_LOX.Count ? active_LOX.Count : active_LH2.Count;
	}

	private void FixedUpdate()
	{
		if (ignited)
		{
			if(pooled > 0)
			{
				rb.AddExplosionForce(pooled, transform.position + engine_offset, pooled);
				pooled = 0;
			}

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

			//Make sure that if this changes, you change the code on StagedEngine
			rb.AddForceAtPosition(transform.InverseTransformVector(Vector3.up * current_thrust), transform.position + engine_offset);

			//deplete fuel
			foreach(FuelSystem fuel in active_LH2)
			{
				fuel.Fuel -= current_thrust / active_LH2.Count;
			}
			foreach(FuelSystem fuel in active_LOX)
			{
				fuel.Fuel -= LOX_to_LH2_ratio * (current_thrust / active_LH2.Count);
			}

			if (Mathf.Approximately(current_thrust, 0))
			{
				ignited = false;
			}
		}
		else
		{
			foreach (FuelSystem fuel in LOX)
			{
				if (fuel.valve_open)
				{
					pooled += fuel.pool_rate * LOX_to_LH2_ratio;
					fuel.Fuel -= fuel.pool_rate * LOX_to_LH2_ratio;
					if (fuel.pump_on)
					{
						pooled += fuel.pool_rate * LOX_to_LH2_ratio;
						fuel.Fuel -= fuel.pool_rate * LOX_to_LH2_ratio;
					}
				}
			}
			foreach(FuelSystem fuel in LH2)
			{
				if (fuel.valve_open)
				{
					pooled += fuel.pool_rate;
					fuel.Fuel -= fuel.pool_rate;
					if (fuel.pump_on)
					{
						pooled += fuel.pool_rate;
						fuel.Fuel -= fuel.pool_rate;
					}
				}
			}
		}
	}

	public void SetThrust(float new_level)
	{
		level = new_level;
		target_thrust = max_thrust * new_level;
	}

}
