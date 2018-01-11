using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EngineThrustReporter : Reporter {

	public Engine engine;
	public List<FloatDisplay> displays;

	protected override void RpcReport()
	{
		float thrust_level = engine.Current_thrust / engine.max_thrust;
		network.AddData(new FloatData(displays, thrust_level, "Engines", .1f));

	}

}
