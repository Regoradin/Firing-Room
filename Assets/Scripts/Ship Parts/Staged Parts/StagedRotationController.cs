using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagedRotationController : MonoBehaviour {

	public Transform ship_transform;
	public Vector3 rotation_speed;
	public float fuel;

	private void FixedUpdate()
	{
		if (fuel >= 0)
		{
			ship_transform.Rotate(rotation_speed);
			fuel -= rotation_speed.magnitude;
		}
		else
		{
			Destroy(this);
		}
	}
}
