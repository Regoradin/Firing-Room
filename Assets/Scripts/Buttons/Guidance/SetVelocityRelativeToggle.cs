using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetVelocityRelativeToggle : Button {

	public VelocityReporter velocity_reporter;
	public GameObject rb_t_object, rb_f_object;	//starts with velocity reporting relative to rb_t_object, can be toggled to rb_f_object
	private bool state = true;

	private void Start()
	{
		CmdAddTask(new SetVelocityRelativeTask(velocity_reporter, rb_t_object.GetComponent<Rigidbody>()));
	}

	private void OnMouseDown()
	{
		state = !state;
		GameObject new_rb_object = state ? rb_t_object : rb_f_object;

		CmdAddTask(new SetVelocityRelativeTask(velocity_reporter, new_rb_object.GetComponent<Rigidbody>()));
	}
}
