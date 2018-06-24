using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ActiveChannelDisplay : NetworkBehaviour {

    private Network network;

    public List<ColorDisplay> displays;

    private void Start()
    {
        if (isServer)
        {
            network = GameObject.Find("Network").GetComponent<Network>();
            RpcSetState(network.Channels);
        }
    }

    private void Update()
    {
        if (isServer)
        {
            RpcSetState(network.Channels);
        }
    }

    [ClientRpc]
    private void RpcSetState(int channels)
    {
        for(int i = 0; i < displays.Count; i++)
        {
            if (i < channels)
            {
                displays[i].state = true;
            }
            else
            {
                displays[i].state = false;
            }
        }
    }
}
