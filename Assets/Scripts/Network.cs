using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Network : NetworkBehaviour
{

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
			for (int i = 0; i < datalines.Count; i++)
			{
				if (i < channels)
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

	private void Awake()
	{
		datalines = new List<Dataline>();
		foreach (Dataline dataline in GetComponentsInChildren<Dataline>())
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
		if (available_datalines.Count < data.channels)
		{
			Debug.Log("Not enough active datalines!");
		}

		int i = Random.Range(0, available_datalines.Count);

		available_datalines[i].AddData(data);
	}
}
