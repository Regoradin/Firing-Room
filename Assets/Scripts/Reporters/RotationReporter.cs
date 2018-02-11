using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationReporter : Reporter {

	public RotationCalculator rotationCalculator;
	public List<FloatDisplay> x_displays, y_displays, z_displays;
	public string category;
	public float size;

	protected override void Report()
	{
		Vector3 rotation = rotationCalculator.current_rotation;

		network.AddData(new FloatData(x_displays, rotation.x, category, size));
		network.AddData(new FloatData(y_displays, rotation.y, category, size));
		network.AddData(new FloatData(z_displays, rotation.z, category, size));
	}
}
