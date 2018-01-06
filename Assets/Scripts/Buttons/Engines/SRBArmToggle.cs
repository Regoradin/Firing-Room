using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SRBArmToggle : Button {

	private bool state = false;
	public SRB srb;

	void OnMouseDown()
	{
		if (hasAuthority)
		{
			state = !state;
			CmdAddTask();
		}
	}

	[Command]
	protected override void CmdAddTask()
	{
		network.AddTask(new SRBArmToggleTask(srb, state));
	}

}
