using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : Button {

	public Staging staging;

	private void OnMouseDown()
	{
		network.AddTask(new StageTask(staging));
	}

}
