using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButton : Button {

	public string message;

	public void OnMouseDown()
	{
		network.AddTask(new DebugTask("cat", 2, message));
	}

}
