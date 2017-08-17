using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		Material mat = lamp.GetComponent<Renderer>().material;

		mat.SetColor("_EmissionColor", new Color(1, 0, 0));

	}

}
