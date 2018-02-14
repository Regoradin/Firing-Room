using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineIgnitedReporter : Reporter {

	public Engine engine;
	public List<BoolDisplay> displays;
	public string category;
	public float size;

	protected override void Report()
	{
		bool ignited = engine.Ignited;
		network.AddData(new BoolData(displays, ignited, category, size));

	}
}
