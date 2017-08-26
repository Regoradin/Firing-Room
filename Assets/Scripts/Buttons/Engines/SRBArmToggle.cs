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
			CmdAddTask(state);
		}
	}

	[Command]
	private void CmdAddTask(bool state)
	{
		network.AddTask(new SRBArmToggleTask(srb, state));
	}

}
