using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DebugLight : NetworkBehaviour {

	private Material mat;
	[SyncVar(hook = "SetGlow")]
	public Color glow_color;

	void Start() {
		mat = GetComponent<Renderer>().material;
	}
	
	public void SetGlow(Color color)
	{
		Debug.Log("Color changing, hook hooked");
		mat.SetColor("_EmissionColor", color);
		glow_color = color;
	}
	
}
