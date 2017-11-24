using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutParachuteTask : Task {

	Parachute chute;

	public CutParachuteTask(Parachute chute):base("Systems", 3)
	{
		this.chute = chute;
	}

	public override void Activate()
	{
		chute.cut = true;
	}
}
