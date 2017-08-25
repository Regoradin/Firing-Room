using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TimeUpdater : NetworkBehaviour {

	public Network network;
	public float delay;

	private float last_message_time = 0;

	void Update() {
		if (isServer)
		{
			if (Time.time >= last_message_time + delay)
			{
				CmdAddData();
			}
		}
	}

	[Command]
	private void CmdAddData()
	{
		network.AddData(new DebugData(Time.time.ToString(), "debug", .1f));
		last_message_time = Time.time;
	}
}
