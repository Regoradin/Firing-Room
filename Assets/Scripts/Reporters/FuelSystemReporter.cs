using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystemReporter : Reporter {

	public FuelSystem fuel;
	public List<BoolDisplay> valve_displays;
	public List<BoolDisplay> pump_displays;
	public string category;
	public float size;


	private new void Start()
	{
		base.Start();
	}

	protected override void Report()
	{
		network.AddData(new BoolData(valve_displays, fuel.valve_open, category, size));
		network.AddData(new BoolData(pump_displays, fuel.pump_on, category, size));
	}

}
