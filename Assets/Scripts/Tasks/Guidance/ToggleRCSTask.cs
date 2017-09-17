using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRCSTask : Task {

	private RCS rcs;
	private bool state;

	public ToggleRCSTask(RCS rcs, bool state): base("Guidance", 2)
	{
		this.rcs = rcs;
		this.state = state;
	}

	public override void Activate()
	{
		rcs.active = state;
	}

}
