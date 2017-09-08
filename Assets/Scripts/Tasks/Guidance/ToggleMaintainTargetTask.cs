using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMaintainTargetTask : Task
{
	private RotationController controller;
	private bool setting;

	public ToggleMaintainTargetTask(RotationController controller, bool setting) :base("Guidance", 2)
	{
		this.controller = controller;
		this.setting = setting;
	}

	public override void Activate()
	{
		controller.maintain_target = setting;
	}
}
