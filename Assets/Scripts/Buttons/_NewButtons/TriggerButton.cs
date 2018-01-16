using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TriggerButton : Button {

	public MonoBehaviour target_behaviour;
	public ITriggerTaskable target;

	new private void Start()
	{
		base.Start();

		target = target_behaviour as ITriggerTaskable;
		if (target == null)
		{
			Debug.Log(name + " was given an unusable target");
		}
	}

	new private void ClickEvent()
	{
		base.ClickEvent();
		CmdAddTriggerTask();
	}

	[Command]
	private void CmdAddTriggerTask()
	{
		network.AddTask(new TriggerTask(target, category, size, send_to_consoles, channels));
	}

}
