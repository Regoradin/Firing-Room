using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VelocityReporter : Reporter {

    public PlanetManager manager;
    public List<FloatDisplay> x_displays, y_displays, z_displays;
    private Vector3 old_pos;

	public string category;
	public float size;


	private void Awake()
	{
        old_pos = Vector3.zero;
    }

	protected override void Report()
	{
        Vector3 new_pos = manager.LatLongAlt();
        Vector3 velocity = new_pos - old_pos;
        old_pos = new_pos;

        network.AddData(new FloatData(x_displays, velocity.x, category, size));
        network.AddData(new FloatData(y_displays, velocity.y, category, size));
        network.AddData(new FloatData(z_displays, velocity.z, category, size));
	}

}
