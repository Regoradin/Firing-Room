﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ToggleMaintainTarget : Button {

	public RotationController rot_controller;
	private bool state;

	private void OnMouseDown()
	{
		//code for doing graphics here also
		state = !state;
		CmdAddTask(new ToggleMaintainTargetTask(rot_controller, state));
	}
}
