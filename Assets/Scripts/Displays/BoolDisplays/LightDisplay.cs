using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDisplay : BoolDisplay {

	new private Light light;

	[ColorUsage(true, true, 0f, 8, .125f, 3f)]
	public Color on_color;
	[ColorUsage(true, true, 0f, 8, .125f, 3f)]
	public Color off_color;

	private void Awake()
	{
		light = GetComponent<Light>();
		light.color = state ? on_color : off_color;
	}

	protected override void SetState(bool new_state)
	{
		state = new_state;
		light.color = new_state ? on_color : off_color;
	}

}
