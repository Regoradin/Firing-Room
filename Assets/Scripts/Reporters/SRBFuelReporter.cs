using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRBFuelReporter : Reporter {

	public SRB srb;
	public List<FloatDisplay> displays;
	public string category;
	public float size;

	protected override void Report()
	{
		float level = srb.Remaining_time / srb.max_time;
		network.AddData(new FloatData(displays, level, category, size));
	}

}
