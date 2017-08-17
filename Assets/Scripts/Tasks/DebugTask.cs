using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTask : Task {

	private string message;

	public DebugTask(string category, int size, string message) : base(category, size)
	{
		this.message = message;
	}

	public override void Activate()
	{
		Debug.Log(message);
	}

}
