using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRCSButton : Button {

	public RCS rcs;
	private bool state = false;

	public void OnMouseDown()
	{
		state = !state;
		CmdAddTask(new ToggleRCSTask(rcs, state));
	}

}
