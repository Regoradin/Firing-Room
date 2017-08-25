using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FuelSystem : NetworkBehaviour {

	public bool is_LOX; //The alternative is LH2

	[SyncVar(hook= "ToggleValve")]
	public bool valve_open = false;
	[SyncVar(hook = "TogglePump")]
	public bool pump_on = false;

	private Engine engine;

	private void Start()
	{
		engine = GetComponentInParent<Engine>();
	}

	private void ToggleValve(bool b)
	{
		valve_open = b;
		engine.CheckFuelSystems();
	}

	private void TogglePump(bool b)
	{
		pump_on = b;
		engine.CheckFuelSystems();
	}
}
