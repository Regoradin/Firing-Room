using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateLimiter : MonoBehaviour {

	private Camera cam;
	private float fps = 1;
	public float FPS
	{
		get { return fps; }
		set
		{
			fps = value;
			CancelInvoke();
			InvokeRepeating("Render", 0, 1 / fps);
		}
	}

	private RenderTexture texture;
	public int width = 1;
	public int height = 1;
	public Material tv_mat;
	private int old_width;


	private void Start()
	{
		cam = GetComponent<Camera>();
		cam.enabled = false;

		texture = cam.targetTexture;

		InvokeRepeating("Render", 0, 1 / fps);
	}

	private void Render()
	{
		cam.Render();
	}

	private void Update()
	{
		if (width != old_width)
		{
			RenderTexture rt = new RenderTexture(width, height, 0);

			cam.targetTexture = rt;
			tv_mat.mainTexture = rt;
		}
		old_width = width;

//		texture.width = width;
//		texture.height = height;
	}
}
