using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DebugButton : Button {

	public string message;
	public GameObject lamp;

	public void OnMouseDown()
	{
		CmdAddTask(new DebugTask("debug", message, 2, lamp));
	}
}
