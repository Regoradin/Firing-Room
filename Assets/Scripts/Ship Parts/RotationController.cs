using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RotationController : NetworkBehaviour {

	private RotationCalculator rot_calc;

	public Transform ship_transform;

	public Vector3 rotation_speed;
	[SyncVar][HideInInspector]
	public Vector3 target_rotation;
	public Vector3 Target_rotation
	{
		get
		{
			return target_rotation;
		}
		set
		{
			target_rotation = value;
			hit_target = false;
		}
	}

	//if maintain_target is set to true, the rotation of the ship will be kept constant through velocity changes. If it is set to false, then the ship won't rotate once it has hit it's target rotation.
	[SyncVar][HideInInspector]
	public bool maintain_target = false;
	private bool hit_target = true;

	private void Start()
	{
		rot_calc = GetComponentInChildren<RotationCalculator>();
	}

	private void FixedUpdate()
	{
		if (!hit_target || maintain_target)
		{
			hit_target = true;

			float x_rot = 0, y_rot = 0, z_rot = 0;

			if (Mathf.Abs(target_rotation.x - rot_calc.current_rotation.x) > rotation_speed.x)
			{
				hit_target = false;
				if (target_rotation.x > rot_calc.current_rotation.x)
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
				hit_target = false;
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
				hit_target = false;
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
		}
	}

}
