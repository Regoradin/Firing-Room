using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpdater : MonoBehaviour {

	public Network network;
	public float delay;

	private float last_message_time = 0;
	
	void Update () {
		if (Time.time >= last_message_time + delay)
		{
			network.AddData(new DebugData(Time.time.ToString(), "debug", .1f));
			last_message_time = Time.time;
		}
	}
}
