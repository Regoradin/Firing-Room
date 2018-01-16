using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Network : NetworkBehaviour {

	[HideInInspector]
	public float delay; //if delay is -1, then there is no connection, but datas and tasks will still be added onto buffers.

	private List<Dataline> datalines;

	private int channels;
	public int Channels
	{
		get
		{
			return channels;
		}
		set
		{
			channels = value;
			for(int i = 0; i < datalines.Count; i++)
			{
				if(i < channels)
				{
					datalines[i].active = true;
				}
				else
				{
					datalines[i].active = false;
				}
			}
		}
	}

	//DEPRACATED. ONLY USED FOR DEBUG DATA B/C I'M LAZY
	//The following fields are data storage fields, which can be modified by incoming Data and read by any interested displays or readouts in mission control.
	[HideInInspector][SyncVar]
	public string debug_message = "debug";
	[HideInInspector][SyncVar]
	public float longitude, latitude, altitude;


	private void Awake()
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
			//If no datalines are available, ignore the category restriction
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
