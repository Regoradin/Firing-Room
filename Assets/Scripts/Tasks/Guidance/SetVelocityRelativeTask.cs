using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVelocityRelativeTask : Task {

	private VelocityReporter reporter;
	private Rigidbody relative_rb;

	public SetVelocityRelativeTask(VelocityReporter reporter, Rigidbody relative_rb):base("Guidance", 3)
	{
		this.reporter = reporter;
		this.relative_rb = relative_rb;
	}

	public override void Activate()
	{
		reporter.reference_rb = relative_rb;
	}
}
