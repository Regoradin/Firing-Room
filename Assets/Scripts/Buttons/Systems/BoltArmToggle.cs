using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltArmToggle : Button {

	public Bolt bolt;
	private bool state = false;

	private void OnMouseDown()
	{
		state = !state;
		CmdAddTask(new BoltArmTask(bolt, state));
	}

}
