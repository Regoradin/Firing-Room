using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBreakTask : Task
{
	private Bolt bolt;

	public BoltBreakTask(Bolt bolt):base("Systems", 1)
	{
		this.bolt = bolt;
	}

	public override void Activate()
	{
		bolt.broken = true;
	}
}
