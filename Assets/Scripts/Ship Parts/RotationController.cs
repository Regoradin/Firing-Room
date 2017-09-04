using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour {

	private RotationCalculator rot_calc;

	public Transform ship_transform;

	public Vector3 rotation_speed;
	public Vector3 target_rotation;


	private void Start()
	{
		rot_calc = GetComponentInChildren<RotationCalculator>();
	}

	private void FixedUpdate()
	{
		float x_rot = 0, y_rot = 0, z_rot = 0;

		if(Mathf.Abs(target_rotation.x - rot_calc.current_rotation.x) > rotation_speed.x)
		{
			if(target_rotation.x > rot_calc.current_rotation.x)
			{
				x_rot = -rotation_speed.x;
			}
			else
			{
				x_rot = rotation_speed.x;
			}
		}
		if (Mathf.Abs(target_rotation.y - rot_calc.current_rotation.y) > rotation_speed.y)
		{
			if (target_rotation.y > rot_calc.current_rotation.y)
			{
				y_rot = rotation_speed.y;
			}
			else
			{
				y_rot = -rotation_speed.y;
			}
		}
		if (Mathf.Abs(target_rotation.z - rot_calc.current_rotation.z) > rotation_speed.z)
		{
			if (target_rotation.z > rot_calc.current_rotation.z)
			{
				z_rot = -rotation_speed.z;
			}
			else
			{
				z_rot = rotation_speed.z;
			}
		}

		ship_transform.Rotate(new Vector3(x_rot, y_rot, z_rot));
		Debug.Log("Rotating by " + x_rot + " " + y_rot + " " + z_rot);
	}

}
