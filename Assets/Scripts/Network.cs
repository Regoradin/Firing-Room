using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour {

	private float delay = 5;
	public float Delay
	{
		get
		{
			return delay;
		}
	}

	private List<Dataline> datalines;

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
		List<Dataline> available_datalines = new List<Dataline>();
		foreach (Dataline dataline in datalines)
		{
			if (dataline.active && dataline.is_uplink && dataline.categories_enabled.Contains(task.category))
			{
				available_datalines.Add(dataline);
			}
		}
		if(available_datalines.Count == 0)
		{
			foreach(Dataline dataline in datalines)
			{
				if (dataline.active && dataline.is_uplink)
				{
					available_datalines.Add(dataline);
				}
			}
		}
		if(available_datalines.Count == 0)
		{
			Debug.Log("No active datalines!");
		}

		int i = Random.Range(0, available_datalines.Count);

		available_datalines[i].AddTask(task);
		Debug.Log("Network added task to dataline " + datalines.IndexOf(available_datalines[i]));
	}
}
