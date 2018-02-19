using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationVelocityReporter : Reporter {

	public RotationCalculator calculator;
	public List<FloatDisplay> x_displays, y_displays, z_displays;
	public string category;
	public float size;

	protected override void Report()
	{
		Vector3 rotation_velocity = (calculator.current_rotation - calculator.last_rotation) / Time.deltaTime;

		network.AddData(new FloatData(x_displays, rotation_velocity.x, category, size));
		network.AddData(new FloatData(y_displays, rotation_velocity.y, category, size));
		network.AddData(new FloatData(z_displays, rotation_velocity.z, category, size));
	}
}
