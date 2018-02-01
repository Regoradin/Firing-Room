using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FuelSystem : NetworkBehaviour, IBoolTaskable {

	public bool is_LOX; //The alternative is LH2

	[SyncVar(hook= "ToggleValve")]
	public bool valve_open = false;
	[SyncVar(hook = "TogglePump")]
	public bool pump_on = false;

	/// <summary>
	/// This will toggle whether the pummp and the valve are open. The button calling this needs to set the bool appropriately to select which one.
	/// </summary>
	/// <param name="b">True for pump, false for valve.</param>
	public void BoolTask(bool b)
	{
		if (b)
		{
			pump_on = !pump_on;
		}
		else
		{
			valve_open = !valve_open;
		}
	}

	public float max_fuel;
	private float fuel;
	public float Fuel
	{
		get { return fuel; }
		set
		{
			fuel = value;
			if (fuel <= 0)
			{
				Debug.Log("Run out of fuel");
				foreach (Engine engine in engines)
				{
					engine.CheckFuelSystems();
				}
			}
			if(fuel >= max_fuel)
			{
				fuel = max_fuel;
			}
		}
	}
	public float pool_rate;

	public List<Engine> engines;

	private void Awake()
	{
		fuel = max_fuel;
	}

	private void ToggleValve(bool b)
	{
		valve_open = !valve_open;
		foreach (Engine engine in engines)
		{
			engine.CheckFuelSystems();
		}
	}

	private void TogglePump(bool b)
	{
		pump_on = !pump_on;
		foreach (Engine engine in engines)
		{
			engine.CheckFuelSystems();
		}
	}
}
