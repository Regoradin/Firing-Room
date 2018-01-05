using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetTargetRotationButton : Button {

	public RotationController rotation_controller;

	public Dial x_dial, y_dial, z_dial;

	private void OnMouseDown()
	{
		CmdAddTask(new Vector3(x_dial.Value, y_dial.Value, z_dial.Value));
		Debug.Log(new Vector3(x_dial.Value, y_dial.Value, z_dial.Value));
	}

	[Command]
	private void CmdAddTask(Vector3 target_rotation)
	{
		network.AddTask(new SetTargetRotationTask(rotation_controller, target_rotation));
	}

}
