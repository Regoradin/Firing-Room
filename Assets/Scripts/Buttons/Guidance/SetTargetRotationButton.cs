using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetTargetRotationButton : Button {

	public RotationController rotation_controller;
	public Vector3 target_rotation;

	private void OnMouseDown()
	{
		CmdAddTask(target_rotation);
	}

	[Command]
	private void CmdAddTask(Vector3 target_rotation)
	{
		network.AddTask(new SetTargetRotationTask(rotation_controller, target_rotation));
	}

}
