using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class METClock : NetworkBehaviour, ITriggerTaskable {

	public float time;
	[SyncVar]
	private bool running = false;

	public void TriggerTask()
	{
		running = !running;
	}

	private void Update()
	{
		if (running)
		{
			time += Time.deltaTime;
		}
	}

}
