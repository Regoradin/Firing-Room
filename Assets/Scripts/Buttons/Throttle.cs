using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Throttle : MonoBehaviour {

	public float max_movement;
	private float min_movement;

	public float throttle_sensitivity = 1;

	protected float level;

	private void Start()
	{		
		min_movement = transform.localPosition.x;

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
