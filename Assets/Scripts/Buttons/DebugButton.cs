using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DebugButton : Button {

	public string message;
	public GameObject lamp;

	public void OnMouseDown()
	{
		CmdAddTask();
	}

	[Command]
	protected override void CmdAddTask()
	{
		network.AddTask(new DebugTask("debug", message, 2, lamp));
	}
}
