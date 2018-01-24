using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericScience : Reporter, ITriggerTaskable {


	public void TriggerTask()
	{
		if (isServer)
		{
			Report();
		}
	}

	private void Update()
	{
		//prevents the thing from sending regular Reports.
	}

	protected override void Report()
	{
		Debug.Log("adding data");
		network.AddData(new DebugData("Science", "Debug", 2));
	}
}
