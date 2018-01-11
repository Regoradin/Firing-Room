using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTask : Task {

	ITriggerTaskable target;

	public TriggerTask(ITriggerTaskable target, string category, float size, bool send_to_consoles = false, int channels = 1):base(category, size, send_to_consoles, channels)
	{
		this.target = target;
	}

	public override void Activate()
	{
		target.TriggerTask();
	}

}
