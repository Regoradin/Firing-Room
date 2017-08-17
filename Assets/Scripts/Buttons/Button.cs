using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	protected Network network;

	private void Start()
	{
		network = GameObject.Find("Network").GetComponent<Network>();
	}
	
}
