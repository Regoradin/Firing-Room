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
			CmdAddTask(level);
		}
	}


	[Command]
	private void CmdAddTask(float level)
	{
		_net.AddTask(new EngineThrottleTask(engine, level));
	}
}
