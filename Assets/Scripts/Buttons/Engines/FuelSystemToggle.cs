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
		if (hasAuthority)
		{
			state = !state;
			CmdAddTask();
		}
	}

	protected override void CmdAddTask()
	{
		Debug.Log("Toggling fuel system here");
		network.AddTask(new FuelSystemToggleTask(fuel_system, state, is_valve));
	}

}
