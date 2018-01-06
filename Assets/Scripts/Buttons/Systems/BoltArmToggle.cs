﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltArmToggle : Button {

	public Bolt bolt;
	private bool state = false;

	private void OnMouseDown()
	{
		state = !state;
		CmdAddTask();
	}

	protected override void CmdAddTask()
	{
		network.AddTask(new BoltArmTask(bolt, state));
	}

}
