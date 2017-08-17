﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour {

	private float delay = 2;
	public float Delay
	{
		get
		{
			return delay;
		}
	}

	private List<Dataline> datalines;

	//The following fields are data storage fields, which can be modified by incoming Data and read by any interested monitors or readouts in mission control.
	[HideInInspector]
	public string debug_message = "debug";
	[HideInInspector]
	public float longitude, latitude, altitude;


	private void Start()
	{
		datalines = new List<Dataline>();
		foreach (Dataline dataline in GetComponents<Dataline>())
		{
			datalines.Add(dataline);
		}
	}

	public void AddTask(Task task)
	{
		if (task.send_to_consoles)
		{
			task.Activate();
		}
		else
		{
			List<Dataline> available_datalines = new List<Dataline>();
			foreach (Dataline dataline in datalines)
			{
				if (dataline.active && dataline.is_uplink && dataline.categories_enabled.Contains(task.category))
				{
					available_datalines.Add(dataline);
				}
			}
			if (available_datalines.Count == 0)
			{
				foreach (Dataline dataline in datalines)
				{
					if (dataline.active && dataline.is_uplink)
					{
						available_datalines.Add(dataline);
					}
				}
			}
			if (available_datalines.Count == 0)
			{
				Debug.Log("No active datalines!");
				return;
			}

			int i = Random.Range(0, available_datalines.Count);

			available_datalines[i].AddTask(task);
		}
	}

	public void AddData(Data data)
	{
		List<Dataline> available_datalines = new List<Dataline>();
		foreach (Dataline dataline in datalines)
		{
			if (dataline.active && !dataline.is_uplink && dataline.categories_enabled.Contains(data.category))
			{
				available_datalines.Add(dataline);
			}
		}
		if (available_datalines.Count == 0)
		{
			foreach (Dataline dataline in datalines)
			{
				if (dataline.active && !dataline.is_uplink)
				{
					available_datalines.Add(dataline);
				}
			}
		}
		if (available_datalines.Count == 0)
		{
			Debug.Log("No active datalines!");
		}

		int i = Random.Range(0, available_datalines.Count);

		available_datalines[i].AddData(data);
	}
}
