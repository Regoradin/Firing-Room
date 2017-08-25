using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterData : Data {

	List<MeterDisplay> displays;
	private float level;

	public MeterData(List<MeterDisplay> displays, float level, string category, float size) : base(category, size)
	{
		this.displays = displays;
		this.level = level;
	}

	public override void Activate()
	{
		foreach(MeterDisplay display in displays)
		{
			display.level = level;
		}
	}
}
