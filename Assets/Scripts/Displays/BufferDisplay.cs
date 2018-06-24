using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BufferDisplay : NetworkBehaviour {

    public Dataline dataline;

    public int signal_threshold;
    private ColorDisplay display;

    private void Start()
    {
        display = GetComponentInChildren<ColorDisplay>();

        if (isServer)
        {
            RpcSetState(dataline.Buffer);
        }
    }

    private void Update()
    {
        if (isServer)
        {
            RpcSetState(dataline.Buffer);
        }
    }

    [ClientRpc]
    private void RpcSetState(int buffer)
    {
        if(buffer >= signal_threshold)
        {
            display.state = true;
        }
        else
        {
            display.state = false;
        }
    }
}
