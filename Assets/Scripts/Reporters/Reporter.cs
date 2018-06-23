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
        network = GameObject.Find("Network").GetComponent<Network>();
        if (isServer)
        {
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
