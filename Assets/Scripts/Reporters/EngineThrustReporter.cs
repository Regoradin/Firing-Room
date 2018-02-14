using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EngineThrustReporter : Reporter {

	public Engine engine;
	public List<FloatDisplay> displays;
	public string category;
	public float size;

	protected override void Report()
	{
		float thrust_level = engine.Current_thrust;
		network.AddData(new FloatData(displays, thrust_level, category, size));

	}

}
