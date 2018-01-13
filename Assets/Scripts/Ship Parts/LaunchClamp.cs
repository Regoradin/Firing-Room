using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LaunchClamp : NetworkBehaviour, ITriggerTaskable {

	[SyncVar(hook = "Disconnect")]
	private bool clamped = true;

	public GameObject rocket;
	private Rigidbody[] rbs;

	void Start () {
		rbs = rocket.GetComponentsInChildren<Rigidbody>();

		foreach(Rigidbody rb in rbs)
		{
			rb.isKinematic = true;
		}
	}

	public void TriggerTask()
	{
		clamped = false;
	}
	private void Disconnect(bool b)
	{
		clamped = false;
		foreach(Rigidbody rb in rbs)
		{
			rb.isKinematic = false;
		}
	}
	
}
