using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCalculator : MonoBehaviour {

	private Rigidbody rb;

	private Vector3 rotation_from_velocity;

	[HideInInspector]
	public Vector3 current_rotation;

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	private void Start()
	{
		rb.velocity = Vector3.up;
	}

	private void Update()
	{
		//Keeps the gyro pointed towards velocity
		transform.rotation = Quaternion.LookRotation(rb.velocity);

		current_rotation = CalculateRotation();
	}

	private Vector3 CalculateRotation()
	{
		Vector3 result = transform.localEulerAngles;

		result.x = result.x > 180 ? result.x - 360 : result.x;
		result.y = result.y > 180 ? - (result.y - 360) : -result.y;		//this is negated just to make the negative and positive sides more intuitive
		result.z = result.z > 180 ? result.z - 360 : result.z;

		return result;
	}
}
