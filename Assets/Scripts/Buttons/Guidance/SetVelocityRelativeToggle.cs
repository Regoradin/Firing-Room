using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetVelocityRelativeToggle : Button {

	public VelocityReporter velocity_reporter;
	public GameObject rb_t_object, rb_f_object;
	private bool state = true;

	private void Start()
	{
		CmdAddTask();
	}

	private void OnMouseDown()
	{
		state = !state;
		CmdAddTask();
	}

	[Command]
	protected override void CmdAddTask()
	{
		Rigidbody new_rb = (state ? rb_t_object : rb_f_object).GetComponent<Rigidbody>();

		network.AddTask(new SetVelocityRelativeTask(velocity_reporter, new_rb));
	}

}
