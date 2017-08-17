using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dataline : MonoBehaviour
{

	public bool active;
	private Network network;
	public bool is_uplink = true;
	public List<string> categories_enabled;

	private List<Task> task_buffer;
	private bool uploading = false;
	private List<Task> tasks_on_line;

	private List<Data> data_buffer;
	private bool downloading = false;
	private List<Data> data_on_line;

	private void Start()
	{
		network = GetComponentInParent<Network>();

		task_buffer = new List<Task>();
		tasks_on_line = new List<Task>();

		data_buffer = new List<Data>();
		data_on_line = new List<Data>();
	}

	private void Update()
	{
		if (is_uplink)
		{
			if (!uploading)
			{
				Upload();
			}
		}
		else
		{
			if (!downloading)
			{
				Download();
			}
		}
	}

	/// <summary>
	/// Switches between uplink and downlink.
	/// </summary>
	public void SwitchMode()
	{
		if (is_uplink)
		{
			StartCoroutine(SwitchToDownlink());
		}
		else
		{
			StartCoroutine(SwitchToUplink());
		}
	}

	private IEnumerator SwitchToDownlink()
	{
		while(tasks_on_line.Count != 0)
		{
			yield return null;
		}
		is_uplink = false;
	}

	private IEnumerator SwitchToUplink()
	{
		while (data_on_line.Count != 0)
		{
			yield return null;
		}
		is_uplink = true;
	}

	//TASK UPLOADING
	/// <summary>
	/// Adds the task to the dataline's buffer
	/// </summary>
	/// <param name="task"></param>
	public void AddTask(Task task)
	{
		if (is_uplink)
		{
			task_buffer.Add(task);
		}
		else
		{
			Debug.Log("Task tried to be added to a downlink dataline!");
		}
	}

	/// <summary>
	/// Uploads the next task in the buffer onto the line
	/// </summary>
	private void Upload()
	{
		if (task_buffer.Count > 0)
		{
			uploading = true;

			Task task_to_upload = task_buffer[0];
			tasks_on_line.Add(task_to_upload);
			task_buffer.Remove(task_to_upload);
			

			Invoke("FinishUpload", task_to_upload.size);
			StartCoroutine(ActivateTask(task_to_upload));
		}
	}

	private void FinishUpload()
	{
		uploading = false;
		//this is probably where we will figure out how to do the graphics and stuff
	}

	private IEnumerator ActivateTask(Task task)
	{
		yield return new WaitForSeconds(network.Delay + task.size);
		tasks_on_line.Remove(task);
		task.Activate();
	}

	//DATA DOWNLOADING
	/// <summary>
	/// Adds the data to the dataline's buffer
	/// </summary>
	/// <param name="data"></param>
	public void AddData(Data data)
	{
		if (!is_uplink)
		{
			data_buffer.Add(data);
		}
		else
		{
			Debug.Log("Data tried to be added to a uplink dataline!");
		}
	}

	/// <summary>
	/// Downloads the next data in the buffer onto the line
	/// </summary>
	private void Download()
	{
		if (data_buffer.Count > 0)
		{
			downloading = true;

			Data data_to_download = data_buffer[0];
			data_on_line.Add(data_to_download);
			data_buffer.Remove(data_to_download);


			Invoke("FinishDownload", data_to_download.size);
			StartCoroutine(ActivateData(data_to_download));
		}
	}

	private void FinishDownload()
	{
		downloading = false;
		//this is probably where we will figure out how to do the graphics and stuff
	}

	private IEnumerator ActivateData(Data data)
	{
		yield return new WaitForSeconds(network.Delay + data.size);
		data_on_line.Remove(data);
		data.Activate(network);
	}

}
