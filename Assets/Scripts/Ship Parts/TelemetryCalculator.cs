using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryCalculator : MonoBehaviour {

	private Rigidbody rb;

	private Vector3 rotation_from_velocity;

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
		rotation_from_velocity = CalculateRotation();

		Debug.Log("velocity: " + rb.velocity);
		Debug.Log("Rotation: " + transform.TransformVector(Vector3.right));
		Debug.Log("Calculated rot: " + rotation_from_velocity);
	}

	private Vector3 CalculateRotation()
	{
		Vector3 velocity = rb.velocity;
		Vector3 rotation = transform.TransformVector(Vector3.right);

		Vector3 result = new Vector3(
			Vector3.Angle((velocity.z * Vector3.forward) + (velocity.y * Vector3.up), (rotation.z * Vector3.forward) + (rotation.y * Vector3.up)),
			Vector3.Angle((velocity.x * Vector3.right) + (velocity.z * Vector3.forward), (rotation.x * Vector3.right) + (rotation.z * Vector3.forward)),
			Vector3.Angle((velocity.x * Vector3.right) + (velocity.y * Vector3.up), (rotation.x * Vector3.right) + (rotation.y * Vector3.up)));

		return result;
	}
}
