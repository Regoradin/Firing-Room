using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TVReporter : Reporter, IFloatTaskable, IVector3Taskable {
	public Camera cam;
	public Material tv_mat;

	[SyncVar]
	public Vector2 resolution;
	public float compression = 1; //this is just used to scale the resolution down to a reasonable size to use for the data.

	public string category;

	private void Awake()
	{
		base.Start();

		cam.enabled = false;
	}

	public void FloatTask(float fps)
	{
		delay = 1 / fps;
	}
	public void Vector3Task(Vector3 new_res)
	{
		resolution = new Vector2(new_res.x, new_res.y);
	}

	protected override void Report()
	{
		float size = resolution.magnitude / compression;
		RenderTexture tex = new RenderTexture((int)resolution.x, (int)resolution.y, 0);
		cam.targetTexture = tex;
		cam.Render();

		network.AddData(new TVData(tv_mat, tex, category, size));
	}
}
