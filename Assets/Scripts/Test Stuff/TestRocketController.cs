using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRocketController : MonoBehaviour {

	public float rotation;
	public float force;

	private void FixedUpdate()
	{
		if (Input.GetButton("Fire1"))
		{
			Thrust(force);
		}


		Turn(rotation * Input.GetAxis("Horizontal"));
	}

	public void Turn(float rotation)
	{
		transform.Rotate(Vector3.right * rotation);
	}

	public void Thrust(float force)
	{
		transform.GetComponent<Rigidbody>().AddForce(transform.TransformVector(Vector3.up * force));
	}

}
