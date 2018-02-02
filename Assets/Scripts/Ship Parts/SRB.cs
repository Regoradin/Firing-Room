﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SRB : NetworkBehaviour, IBoolTaskable {

	private Rigidbody rb;
	public transform thrust_position;

	public float thrust;
	public float time;
	private float end_time;

	[SyncVar]
	private bool armed = false;
	[SyncVar(hook ="Fire")]
	private bool firing = false;

	public void BoolTask(bool b)
	{
		if (b)
		{
			firing = true;
		}
		else
		{
			armed = !armed;
		}
	}

	private bool spent;

	private void Start()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		if (firing && !spent)
		{
			rb.AddForceAtPosition(transform.TransformVector(thrust * Vector3.up), thrust_position.position);

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
