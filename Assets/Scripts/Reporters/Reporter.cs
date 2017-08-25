using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Reporter : NetworkBehaviour {

	protected Network network;

	void Start () {
		network = GameObject.Find("Network").GetComponent<Network>();
	}
	
}
