﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityReporter : Reporter {

	public List<FloatDisplay> displays;

	private Rigidbody rb;
	[HideInInspector]
	public Rigidbody reference_rb;  //the rigidbody that has the reference 0 velocity;

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	protected override void Report()
	{

		float calculated_velocity = rb.velocity.magnitude;
		if(reference_rb != null)
		{
			calculated_velocity = (rb.velocity - reference_rb.velocity).magnitude;
		}

		network.AddData(new FloatData(displays, calculated_velocity, "Guidance", .1f));
	}

}
