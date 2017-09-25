using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBreakButton : Button {

	public Bolt bolt;

	private void OnMouseDown()
	{
		network.AddTask(new BoltBreakTask(bolt));
	}

}
