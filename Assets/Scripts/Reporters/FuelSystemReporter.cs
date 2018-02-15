using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystemReporter : Reporter {

	public FuelSystem fuel;
	public List<FloatDisplay> fuel_displays;
	public string category;
	public float size;


	private new void Start()
	{
		base.Start();
	}

	protected override void Report()
	{
		network.AddData(new FloatData(fuel_displays, fuel.Fuel, category, size));
	}

}
