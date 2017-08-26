using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SRB : NetworkBehaviour {

	private Rigidbody rb;
	private Vector3 thrust_position;

	public float thrust;
	public float time;
	private float end_time;

	[SyncVar]
	public bool armed = false;
	[SyncVar(hook ="Fire")]
	public bool firing = false;

	private bool spent;

	private void Start()
	{
		rb = GetComponentInParent<Rigidbody>();
		thrust_position = transform.position;
	}

	private void FixedUpdate()
	{
		if (firing && !spent)
		{
			rb.AddForceAtPosition(thrust * Vector3.up, thrust_position);

			if (Time.time >= end_time)
			{
				firing = false;
				spent = true;
			}
		}
	}

	private void Fire(bool b)
	{
		if(!spent && armed && b)
		{
			firing = b;
			end_time = Time.time + time;
		}
	}

}
