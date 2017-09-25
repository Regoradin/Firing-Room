using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bolt : NetworkBehaviour {

	[SyncVar]
	public bool armed = false;
	[SyncVar(hook = "Break")]
	public bool broken = false;

	private void Break(bool b)
	{
		if(b && armed)
		{
			broken = true;
		}
	}

}
