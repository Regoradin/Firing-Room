using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BoolButton : Button {

	private IBoolTaskable target;
	public MonoBehaviour target_behviour;

	public bool b;

	new private void Start()
	{
		base.Start();

		target = target_behviour as IBoolTaskable;
		if(target == null)
		{
			Debug.Log(name + " was given an unusable function");
		}
	}

	private void OnMouseDown()
	{
		CmdAddBoolTask(b);
	}

	[Command]
	private void CmdAddBoolTask(bool b)
	{
		network.AddTask(new BoolTask(target, b, category, size, send_to_consoles, channels));
	}

}
