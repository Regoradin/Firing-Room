using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatData : Data {

	List<FloatDisplay> displays;
	private float level;

	public FloatData(List<FloatDisplay> displays, float level, string category, float size) : base(category, size)
	{
		this.displays = displays;
		this.level = level;
	}

	public override void Activate()
	{
		foreach(FloatDisplay display in displays)
		{
			display.level = level;
		}
	}
}
