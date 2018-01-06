using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBreakButton : Button {

	public Bolt bolt;

	private void OnMouseDown()
	{
		CmdAddTask();
	}

	protected override void CmdAddTask()
	{
		network.AddTask(new BoltBreakTask(bolt));
	}

}
