using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Button : NetworkBehaviour {

	protected Network network;

	public string category;
	public float size = 1;
	public bool send_to_consoles = false;
	public int channels = 1;

	protected void Start()
	{
		network = GameObject.Find("Network").GetComponent<Network>();
	}

}
