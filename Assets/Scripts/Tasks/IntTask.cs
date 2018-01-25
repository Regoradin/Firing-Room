using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntTask : Task {

	private IIntTaskable target;
	private int i;

	public IntTask(IIntTaskable target, int i, string category, float size, bool send_to_consoles = false, int channels = 1):base(category, size, send_to_consoles, channels)
	{
		this.target = target;
		this.i = i;
	}

	public override void Activate()
	{
		target.IntTask(i);
	}
}
