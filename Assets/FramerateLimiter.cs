using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateLimiter : MonoBehaviour {

	private Camera cam;
	private float fps;
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

	private void Start()
	{
		cam = GetComponent<Camera>();
		cam.enabled = false;

		InvokeRepeating("Render", 0, 1 / fps);
	}

	private void Render()
	{
		cam.Render();
	}
}
