using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Button : NetworkBehaviour {

	protected Network network;

	private void Start()
	{
		network = GameObject.Find("Network").GetComponent<Network>();
	}

	[Command]
	protected abstract void CmdAddTask();

}
