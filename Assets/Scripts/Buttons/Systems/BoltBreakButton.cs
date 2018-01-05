using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBreakButton : Button {

	public Bolt bolt;

	private void OnMouseDown()
	{
		CmdAddTask(new BoltBreakTask(bolt));
	}

}
