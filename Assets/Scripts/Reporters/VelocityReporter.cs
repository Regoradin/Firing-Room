using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityReporter : Reporter {

	public List<FloatDisplay> displays;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	protected override void Report()
	{
		network.AddData(new FloatData(displays, rb.velocity.magnitude, "Guidance", .1f));
	}

}
