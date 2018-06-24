using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDisplay : BoolDisplay {

	new private Light light;

	[ColorUsage(true, true)]
	public Color off_color;
    [ColorUsage(true, true)]
    public Color on_color;


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
