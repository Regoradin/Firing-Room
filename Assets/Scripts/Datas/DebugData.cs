using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugData : Data {

	private string message;
	public string Message { get { return message; } }

	public DebugData(string message, string category, float size) : base(category, size)
	{
		this.message = message;
	}

	public override void Activate()
	{
		Debug.Log(message);
	}

}
