using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRBArmToggleTask : Task {

	private SRB srb;
	private bool state;

	public SRBArmToggleTask(SRB srb, bool state):base("Engines", 1)
	{
		this.srb = srb;
		this.state = state;
	}

	public override void Activate()
	{
		srb.armed = state;
	}

}
