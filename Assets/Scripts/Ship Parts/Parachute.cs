using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Parachute : NetworkBehaviour, IBoolTaskable {

	public float parachute_constant;

	private Rigidbody rb;
	private PlanetManager planet;

	[SyncVar(hook = "Open")]
	public bool open = false;
	[SyncVar(hook = "Cut")]
	public bool cut = false;
	public void BoolTask(bool b)
	{
		if (b)
		{
			cut = true;
		}
		else
		{
			open = true;
		}
	}

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

	private void Open(bool b)
	{
		if (!cut)
		{
			open = true;
		}
	}

	private void Cut(bool b)
	{
		open = false;
		cut = true;
	}


}
