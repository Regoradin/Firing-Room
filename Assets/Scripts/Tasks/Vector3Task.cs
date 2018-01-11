using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Task : Task {

	private IVector3Taskable target;
	private Vector3 vector;

	public Vector3Task(IVector3Taskable target, Vector3 vector, string category, float size, bool send_to_consoles = false, int channels = 1) : base(category, size, send_to_consoles, channels)
	{
		this.target = target;
		this.vector = vector;
	}

	public override void Activate()
	{
		target.Vector3Task(vector);
	}
}
