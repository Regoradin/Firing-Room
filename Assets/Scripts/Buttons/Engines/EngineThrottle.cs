using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EngineThrottle : Throttle {

	public Engine engine;

	new private void OnMouseDrag()
	{
		if (hasAuthority)
		{
			base.OnMouseDrag();
			CmdAddTask();
		}
	}


	[Command]
	protected override void CmdAddTask()
	{
		_net.AddTask(new EngineThrottleTask(engine, level));
	}
}
