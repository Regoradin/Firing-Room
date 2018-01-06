using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : Button {

	public Staging staging;

	private void OnMouseDown()
	{
		CmdAddTask();
	}

	protected override void CmdAddTask()
	{
		network.AddTask(new StageTask(staging));
	}

}
