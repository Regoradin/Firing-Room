using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DebugTask : Task {

	private string message;
	private GameObject lamp;

	public DebugTask(string category, string message, float size, GameObject lamp) : base(category, size)
	{
		this.message = message;
		this.lamp = lamp;
	}

	public override void Activate()
	{
		Debug.Log(message + " at " + Time.time);
		lamp.GetComponent<DebugLight>().glow_color = Color.red;
	}
}
