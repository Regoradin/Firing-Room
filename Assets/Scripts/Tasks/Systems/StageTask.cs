using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTask : Task
{
	Staging staging;

	public StageTask(Staging staging) : base("Systems", 3)
	{
		this.staging = staging;
	}

	public override void Activate()
	{
		staging.connected = false;
	}
}
