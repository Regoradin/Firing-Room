using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Vector3Button : Button {

	private IVector3Taskable target;
	public MonoBehaviour target_behaviour;

	public Vector3 vector;

	new private void Start()
	{
		base.Start();

		target = target_behaviour as IVector3Taskable;
		if(target == null)
		{
			Debug.Log(name + " was given an unusable target");
		}
	}

	private void OnMouseDown()
	{
		CmdAddVector3Task(vector);
	}

	[Command]
	private void CmdAddVector3Task(Vector3 vector)
	{
		network.AddTask(new Vector3Task(target, vector, category, size, send_to_consoles, channels));
	}
}
