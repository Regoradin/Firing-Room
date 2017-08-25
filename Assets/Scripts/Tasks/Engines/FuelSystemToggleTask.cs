using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystemToggleTask : Task {

	private FuelSystem fuel;
	private bool state;
	private bool is_valve;	//the alternateive being a pump

	public FuelSystemToggleTask(FuelSystem fuel, bool state, bool is_valve):base("Engines", 1)
	{
		this.fuel = fuel;
		this.state = state;
		this.is_valve = is_valve;
	}

	public override void Activate()
	{
		if (is_valve)
		{
			fuel.valve_open = state;
		}
		else
		{
			fuel.pump_on = state;
		}
	}

}
