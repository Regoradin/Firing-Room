using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetRotationTask : Task {

	private RotationController rot_controller;
	private Vector3 target_rotation;

	public SetTargetRotationTask(RotationController rot_controller, Vector3 target_rotation):base("Guidance", 2)
	{
		this.target_rotation = target_rotation;
		this.rot_controller = rot_controller;
	}

	public override void Activate()
	{
		rot_controller.target_rotation = target_rotation;
		Debug.Log("Task Activated");
	}

}
