using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAuthSetter : NetworkBehaviour {

	private List<NetworkIdentity> player_controls;

	void Start()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Debug Control"))
		{
			CmdAssignAuthority(obj.GetComponent<NetworkIdentity>());
		}
	}

    [Command]
    void CmdAssignAuthority(NetworkIdentity net_id)
    {
        //if (net_id.clientAuthorityOwner != null)
        //{
            net_id.RemoveClientAuthority(net_id.clientAuthorityOwner);
        ///}
        net_id.AssignClientAuthority(connectionToClient);
    }

}
