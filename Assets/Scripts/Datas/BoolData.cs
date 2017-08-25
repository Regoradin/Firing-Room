using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolData : Data {

	private List<BoolDisplay> displays;
	private bool state;

	public BoolData(List<BoolDisplay> displays, bool state, string category, float size ) : base(category, size)
	{
		this.displays = displays;
		this.state = state;
	}

	public override void Activate()
	{
		foreach(BoolDisplay display in displays)
		{
			display.state = state;
		}
	}

}
