using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRBFireButtonTask : Task {

	private SRB srb;

	public SRBFireButtonTask(SRB srb):base("Engines", 1)
	{
		this.srb = srb;
	}

	public override void Activate()
	{
		srb.firing = true;
	}
}
