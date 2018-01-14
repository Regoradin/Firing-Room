using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FloatButton : Button {

	private IFloatTaskable target;
	public MonoBehaviour target_behaviour;

	public float value = 0;

	new private void Start()
	{
		base.Start();

		target = target_behaviour as IFloatTaskable;
		if(target == null)
		{
			Debug.Log(name + " was given an unusable target!");
		}
	}

	new private void OnMouseDown()
	{
		base.OnMouseDown();
		CmdAddFloatTask(value);
	}

	[Command]
	private void CmdAddFloatTask(float input)
	{
		network.AddTask(new FloatTask(target, input, category, size, send_to_consoles, channels));
	}

}
