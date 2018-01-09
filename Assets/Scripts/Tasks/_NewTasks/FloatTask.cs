using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTask : Task
{

	IFloatTaskable target;
	float input;

	public FloatTask(IFloatTaskable target, float input, string category, float size, bool send_to_consoles = false, int channels = 1) : base(category, size, send_to_consoles, channels)
	{
		this.target = target;
		this.input = input;
	}

	public override void Activate()
	{
		target.FloatTask(input);
	}

}
