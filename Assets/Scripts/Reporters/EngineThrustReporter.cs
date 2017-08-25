using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EngineThrustReporter : Reporter {

	public Engine engine;
	public List<MeterDisplay> displays;

	public float delay;
	private float last_message_time = 0;

	private void Update()
	{
		if (isServer)
		{
			if (Time.time >= last_message_time + delay)
			{
				last_message_time = Time.time;

				float thrust_level = engine.Current_thrust / engine.max_thrust;
				network.AddData(new MeterData(displays, thrust_level, "Engines", .1f));
			}
		}
	}

}
