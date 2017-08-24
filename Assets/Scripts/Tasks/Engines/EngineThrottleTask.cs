using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineThrottleTask : Task {

	private float level;
	private Engine engine;

	public EngineThrottleTask(float level, Engine engine):base("Engines", .1f)
	{
		this.level = level;
		this.engine = engine;
	}

	public override void Activate()
	{
		engine.level = level;
	}

}
