﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StagingBolts : NetworkBehaviour {

	private List<Bolt> bolts;
	private Staging staging;

	private void Awake()
	{
		bolts = new List<Bolt>();
		staging = GetComponent<Staging>();

		foreach(Bolt bolt in gameObject.GetComponents<Bolt>())
		{
			bolts.Add(bolt);
		}
	}

	private void Update()
	{
		CheckBolts();
	}

	public void CheckBolts()
	{
		int unbroken_bolts = 0;

		foreach(Bolt bolt in bolts)
		{
			if (!bolt.broken)
			{
				unbroken_bolts++;
			}
		}
		
		if(unbroken_bolts == 0)
		{
			staging.Stage(false);
		}
	}


}
