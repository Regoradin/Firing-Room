using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Data {

	public Network network;
	public string category;
	public float size;
	public int channels;

	public Data(string category, float size, int channels = 1)
	{
		this.category = category;
		this.size = size;
		this.channels = channels;
	}

	public abstract void Activate(Network network);
}
