using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Reporter : NetworkBehaviour {

	protected Network network;

	[SyncVar]
	public float frequency;

    protected void Start()
    {
        if (isServer)
        {
            network = GameObject.Find("Network").GetComponent<Network>();
            StartCoroutine(ReportCycle());
        }
    }

    private IEnumerator ReportCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / frequency);
            Report();
        }
    }

	protected virtual void Report()
	{
		Debug.Log("Report not implemented on " + name);
	}
	
}
