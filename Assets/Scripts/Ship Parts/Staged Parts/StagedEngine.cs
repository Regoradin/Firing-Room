using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagedEngine : ShipPart {

	public Rigidbody rb;
	public float current_thrust;
	public Transform engine_location;
	public float fuel;
	public ParticleSystem particles;


	private void FixedUpdate()
	{
		if (fuel > 0)
		{
			rb.AddForceAtPosition(transform.TransformVector(Vector3.forward * current_thrust), engine_location.position);
			fuel -= current_thrust;
			Debug.Log("Staged engine fuel: " + fuel);
		}
		else
		{
			Debug.Log("Destroying engine");
			Destroy(this);
		}
	}

	private void OnDestroy()
	{
		particles.Stop();
	}
}
