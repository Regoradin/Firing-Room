using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Button : NetworkBehaviour {

	private Network network;

	private void Start()
	{
		network = GameObject.Find("Network").GetComponent<Network>();
	}

	[Command]
	protected void CmdAddTask(Task task)
	{
		if (hasAuthority)
		{
			network.AddTask(task);
		}
	}
}
