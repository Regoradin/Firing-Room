using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour {

	public float parachute_constant;

	private Rigidbody rb;
	private PlanetManager planet;

	public bool open = false;

	private void Start()
	{
		rb = GetComponentInParent<Rigidbody>();
		planet = GetComponentInParent<PlanetManager>();
	}

	private void FixedUpdate()
	{
		if (open)
		{
			float lift_force = parachute_constant * rb.velocity.sqrMagnitude * planet.AirDensity();

			rb.AddForce(lift_force * -rb.velocity.normalized);
		}
	}


}
