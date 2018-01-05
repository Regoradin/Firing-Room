using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : Button {

	public Staging staging;

	private void OnMouseDown()
	{
		CmdAddTask(new StageTask(staging));
	}

}
