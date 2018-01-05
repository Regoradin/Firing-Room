using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task {

	public string category;
	public float size;
	public int channels;
	public bool send_to_consoles;

	public Task(string category, float size, bool send_to_consoles = false, int channels = 1)
	{
		this.category = category;
		this.size = size;
		this.send_to_consoles = send_to_consoles;
		this.channels = channels;
	}

	
	public abstract void Activate();
}
