using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dataline : MonoBehaviour
{

	public bool active;
	private Network network;
	public bool is_uplink = true;
	public List<string> categories_enabled;
	private List<Task> buffer;

	private bool uploading = false;

	private void Start()
	{
		network = GetComponentInParent<Network>();
		buffer = new List<Task>();
	}

	private void Update()
		{
			if (!uploading)
			{
				Upload();
			}
		}

	/// <summary>
	/// Adds the task to the dataline's buffer
	/// </summary>
	/// <param name="task"></param>
	public void AddTask(Task task)
	{
		buffer.Add(task);
	}

	/// <summary>
	/// Uploads the next task in the buffer onto the line
	/// </summary>
	private void Upload()
	{
		if (buffer.Count > 0)
		{
			uploading = true;

			Task task_to_upload = buffer[0];
			buffer.RemoveAt(0);

			Invoke("FinishUpload", task_to_upload.size);
			StartCoroutine(ActivateTask(task_to_upload));
			Debug.Log("uploading to buffer at " + Time.time);
		}
	}

	private void FinishUpload()
	{
		uploading = false;
		//this is probably where we will figure out how to do the graphics and stuff
		Debug.Log("finshed upload at " + Time.time);
	}

	private IEnumerator ActivateTask(Task task)
	{
		yield return new WaitForSeconds(network.Delay + task.size);
		task.Activate();
	}
}
