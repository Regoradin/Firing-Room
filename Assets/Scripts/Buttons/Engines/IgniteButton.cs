using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class IgniteButton : Button {

	public Engine engine;

	private void OnMouseDown()
	{
		CmdAddTask();
	}

	[Command]
	private void CmdAddTask()
	{
		network.AddTask(new IgniteButtonTask(engine));
	}
}
