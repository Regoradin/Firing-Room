using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bolt : NetworkBehaviour, IBoolTaskable {

	[SyncVar]
	public bool armed = false;
	[SyncVar]
	public bool broken = false;

	public void BoolTask(bool b)
	{
		if (b)
		{
            Break();
		}
		else
		{
			armed = !armed;
		}
	}

	private void Break()
	{
		if(armed)
		{
			broken = true;
		}
	}

}
