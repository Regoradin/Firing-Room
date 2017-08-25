using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FuelSystemToggle : Button {

	private bool state = false;
	public FuelSystem fuel_system;
	public bool is_valve;	//the alternative being a pump

	private void OnMouseDown()
	{
		CmdAddTask(!state);
		state = !state;
	}

	[Command]
	private void CmdAddTask(bool state)
	{
		network.AddTask(new FuelSystemToggleTask(fuel_system, state, is_valve));
	}

}
