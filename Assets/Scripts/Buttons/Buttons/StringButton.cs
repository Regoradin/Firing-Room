using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StringButton : Button {

	private IStringTaskable target;
	public MonoBehaviour target_behaviour;

	public string value;

	new private void Start()
	{
		base.Start();

		target = target_behaviour as IStringTaskable;
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
			CmdAddStringTask(value);
		}
	}

	[Command]
	private void CmdAddStringTask(string input)
	{
		network.AddTask(new StringTask(target, input, category, size, send_to_consoles, channels));
	}
}
