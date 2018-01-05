using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SRBFireButton : Button {

	public SRB srb;

	private void OnMouseDown()
	{
		if (hasAuthority)
		{
			CmdAddTask(new SRBFireButtonTask(srb));
		}
	}
}
