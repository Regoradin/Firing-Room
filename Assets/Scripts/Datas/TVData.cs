using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TVData : Data {

	private Material mat;
	private RenderTexture tex;

	public TVData(Material mat, RenderTexture tex, string category, float size):base(category, size)
	{
		this.mat = mat;
		this.tex = tex;
	}

	public override void Activate()
	{
		//		mat.mainTexture = tex;
		RpcSetTexture();
	}

	[ClientRpc]
	private void RpcSetTexture()
	{
		mat.mainTexture = tex;
	}

}
