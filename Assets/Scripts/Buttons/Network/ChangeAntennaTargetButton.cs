using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChangeAntennaTargetButton : Button {

	public float latitude, longitude, altitude;
	public Antenna antenna;

	public void OnMouseDown()
	{
		if (hasAuthority)
		{
			CmdAddTask();
		}
	}

	[Command]
	protected override void CmdAddTask()
	{
		network.AddTask(new ChangeAntennaTargetTask(antenna, latitude, longitude, altitude));
	}

}
