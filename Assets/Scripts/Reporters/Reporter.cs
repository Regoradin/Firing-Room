using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Reporter : NetworkBehaviour {

	protected Network network;
	private float last_message_time;

	public float delay;

	protected void Start () {
		network = GameObject.Find("Network").GetComponent<Network>();
	}

	private void Update()
	{
		if (isServer)
		{
			if (Time.time >= last_message_time + delay)
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
