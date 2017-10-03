using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagedEngine : MonoBehaviour {

	public Rigidbody rb;
	public float current_thrust;
	public Vector3 engine_offset;
	public float fuel;


	private void FixedUpdate()
	{
		if (fuel > 0)
		{
			rb.AddForceAtPosition(transform.InverseTransformVector(Vector3.up * current_thrust), transform.position + engine_offset);
			fuel -= current_thrust;
			Debug.Log("Staged engine fuel: " + fuel);
		}
		else
		{
			Debug.Log("Destroying engine");
			Destroy(this);
		}
	}
}
