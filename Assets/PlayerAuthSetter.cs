using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAuthSetter : NetworkBehaviour {

	private NetworkIdentity light_net;

	void Start()
	{
		light_net = GameObject.Find("Debug Button").GetComponent<NetworkIdentity>();

		CmdAssignAuthority();
	}

	[Command]
	void CmdAssignAuthority()
	{
		Debug.Log("Assigning Authority");
		light_net.RemoveClientAuthority(light_net.clientAuthorityOwner);
		light_net.AssignClientAuthority(connectionToClient);
	}
}
