using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Throttle : Button {

	public float max_movement;
	private float min_movement;

	public float throttle_sensitivity = 1;

	private bool active = false;

	protected float level;
	protected Network _net;

	private void Start()
	{
		min_movement = transform.localPosition.x;

		//This needs to exist for some reason, the standard button.network didn't work.
		_net = GameObject.Find("Network").GetComponent<Network>();
	}

	protected void OnMouseDrag()
	{
		transform.Translate(new Vector3(Input.GetAxis("Mouse Y") * throttle_sensitivity, 0));

		transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, min_movement, max_movement), transform.localPosition.y, transform.localPosition.z);

		CalculateLevel();
	}

	private void CalculateLevel()
	{
		float range = max_movement - min_movement;
		level = (transform.localPosition.x - min_movement) / range;
	}


}
