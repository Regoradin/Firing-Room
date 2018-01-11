using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolTask : Task {

	private IBoolTaskable target;
	private bool b;

	public BoolTask(IBoolTaskable target, bool b, string category, float size, bool send_to_consoles = false, int channels = 1) : base(category, size, send_to_consoles, channels)
	{
		this.target = target;
		this.b = b;
	}

	public override void Activate()
	{
		target.BoolTask(b);
	}
}
