﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChangeAntennaTargetTask : Task
{

	private float target_lat, target_long, target_alt;
	private Antenna antenna;

	public ChangeAntennaTargetTask(Antenna antenna, float new_lat, float new_long, float new_alt):base("Network", 3, true)
	{
		this.antenna = antenna;
		this.target_lat = new_lat;
		this.target_long = new_long;
		this.target_alt= new_alt;
	}

	public override void Activate()
	{
		antenna.target = new Vector3(target_lat, target_long, target_alt);
	}

}