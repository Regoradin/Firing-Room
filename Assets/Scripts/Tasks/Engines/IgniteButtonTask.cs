using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteButtonTask : Task {

	private Engine engine;

	public IgniteButtonTask(Engine engine):base("Engines", 3)
	{
		this.engine = engine;
	}

	public override void Activate()
	{
		engine.ignited = true;
	}
}
