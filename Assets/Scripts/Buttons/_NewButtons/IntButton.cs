using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class IntButton : Button {
	
	private IIntTaskable target;
	public MonoBehaviour target_behaviour;

	public int value;

	new private void Start()
	{
		base.Start();

		target = target_behaviour as IIntTaskable;
		if (target == null)
		{
			Debug.Log(name + " was given an unusable target!");
		}
	}

	new private void ClickEvent()
	{
		base.ClickEvent();
		if (isServer)
		{
			CmdAddIntTask(value);
		}
	}

	[Command]
	private void CmdAddIntTask(int input)
	{
		network.AddTask(new IntTask(target, input, category, size, send_to_consoles, channels));
	}
}
