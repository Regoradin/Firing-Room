using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bolt : NetworkBehaviour, IBoolTaskable {

	[SyncVar]
	private bool armed = false;
	[SyncVar(hook = "Break")]
	public bool broken = false;

	public void BoolTask(bool b)
	{
		if (b)
		{
			broken = true;
		}
		else
		{
			armed = !armed;
		}
	}

	private void Break(bool b)
	{
		if(b && armed)
		{
			broken = true;
		}
	}

}
