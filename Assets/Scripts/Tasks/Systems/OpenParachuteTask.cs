using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenParachuteTask : Task {

	Parachute chute;

	public OpenParachuteTask(Parachute chute):base("Systems", 3)
	{
		this.chute = chute;
	}

	public override void Activate()
	{
		chute.open = true;
	}
}
