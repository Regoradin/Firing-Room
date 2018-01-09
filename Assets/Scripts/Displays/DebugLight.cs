using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DebugLight : NetworkBehaviour, ITriggerTaskable {

	private Material mat;
	[SyncVar(hook = "SetGlow")]
	public Color glow_color;

	void Start() {
		mat = GetComponent<Renderer>().material;
	}
	
	public void SetGlow(Color color)
	{
		Debug.Log("Setting color, hook hoooked");
		mat.SetColor("_EmissionColor", color);
		glow_color = color;
	}

	public void TriggerTask()
	{
		glow_color = new Color(1, 0, 0);
	}
	
}
