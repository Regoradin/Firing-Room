using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButton : Button {

	public string message;
	public GameObject lamp;

	public void OnMouseDown()
	{
		network.AddTask(new DebugTask("debug", message, 2, lamp));
	}

}
