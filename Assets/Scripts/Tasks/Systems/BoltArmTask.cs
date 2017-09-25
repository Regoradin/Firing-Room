using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltArmTask : Task
{

	private Bolt bolt;
	private bool state;

	public BoltArmTask(Bolt bolt, bool state):base("Systems", 2)
	{
		this.bolt = bolt;
		this.state = state;
	}


	public override void Activate()
	{
		bolt.armed = state;
	}
}
