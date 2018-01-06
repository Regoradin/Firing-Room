using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetTargetRotationButton : Button {

	public RotationController rotation_controller;

	public Dial x_dial, y_dial, z_dial;
	private Vector3 target_rotation;

	private void OnMouseDown()
	{
		target_rotation = new Vector3(x_dial.Value, y_dial.Value, z_dial.Value);
		CmdAddTask();
	}

	[Command]
	protected override void CmdAddTask()
	{
		network.AddTask(new SetTargetRotationTask(rotation_controller, target_rotation));
	}

}
