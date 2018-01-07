using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TriggerButton : Button {

	public MonoBehaviour target_behaviour;
	private ITriggerTaskable target;

	private void Start()
	{
		Debug.Log("Start got called");
		target = target_behaviour as ITriggerTaskable;
		Debug.Log(target);
		if (target == null)
		{
			Debug.Log(name + " was given an unusable target");
		}
		else
		{
			Debug.Log(target);
		}
	}

	private void OnMouseDown()
	{
		CmdAddTriggerTask();
	}

	[Command]
	private void CmdAddTriggerTask()
	{
		Debug.Log("adding trigger task");
		network.AddTask(new TriggerTask(target, category, size, send_to_consoles, channels));
	}

}
