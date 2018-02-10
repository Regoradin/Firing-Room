using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Reporter : NetworkBehaviour {

	protected Network network;
	private float last_message_time;

	[SyncVar]
	public float frequency;

	protected void Start () {
		network = GameObject.Find("Network").GetComponent<Network>();
	}

	private void Update()
	{
		if (isServer)
		{
			if (Time.time >= last_message_time + 1/frequency)
			{
				last_message_time = Time.time;

				Report();
			}
		}
	}

	protected virtual void Report()
	{
		Debug.Log("Report not implemented on " + name);
	}
	
}
