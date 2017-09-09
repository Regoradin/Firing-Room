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
		CmdAddTask(rb_t_object);
	}

	private void OnMouseDown()
	{
		state = !state;
		GameObject new_rb_object = state ? rb_t_object : rb_f_object;

		CmdAddTask(new_rb_object);
	}

	[Command]
	private void CmdAddTask(GameObject rb_object)
	{
		Rigidbody rb = rb_object.GetComponent<Rigidbody>();
		GameObject.Find("Network").GetComponent<Network>().AddTask(new SetVelocityRelativeTask(velocity_reporter, rb));
		//For some reason this won't find the network... this is a really bad fix but it should work.
	}

}
