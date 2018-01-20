using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystemReporter : Reporter {

	private FuelSystem fuel;
	public List<BoolDisplay> valve_displays;
	public List<BoolDisplay> pump_displays;

	private new void Start()
	{
		base.Start();
		fuel = GetComponent<FuelSystem>();
	}

	protected override void Report()
	{
		network.AddData(new BoolData(valve_displays, fuel.valve_open, "Engines", .1f));
		network.AddData(new BoolData(pump_displays, fuel.pump_on, "Engines", .1f));
	}

}
