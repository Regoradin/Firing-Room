using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReporter : Reporter {

	public PlanetManager manager;
	public List<FloatDisplay> x_displays, y_displays, z_displays;
	public string category;
	public float size;

	protected override void Report()
	{
        Vector3 pos = manager.LatLongAlt();

		network.AddData(new FloatData(x_displays, pos.x, category, size));
		network.AddData(new FloatData(y_displays, pos.y, category, size));
		network.AddData(new FloatData(z_displays, pos.z, category, size));
	}

}
