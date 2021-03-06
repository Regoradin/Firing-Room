﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDisplay : BoolDisplay {

	private Material mat;

	[ColorUsage(true, true)]
	public Color off_color;
    [ColorUsage(true, true)]
	public Color on_color;

	private void Awake()
	{
		mat = GetComponent<Renderer>().material;
		mat.color = state ? on_color : off_color;
	}

	protected override void SetState(bool new_state)
	{
		state = new_state;
		mat.color = new_state ? on_color : off_color;
	}

}
