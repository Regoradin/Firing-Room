using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EngineThrottle : Throttle {

	public Engine engine;

	new private void OnMouseDrag()
	{
		base.OnMouseDrag();
		CmdAddTask();
	}

	[Command]
	private void CmdAddTask()
	{
		_net.AddTask(new EngineThrottleTask(level, engine));
	}
}
