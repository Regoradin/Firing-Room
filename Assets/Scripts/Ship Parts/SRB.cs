using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SRB : ShipPart, IBoolTaskable {

	private Rigidbody rb;
	public Transform thrust_position;
	private ParticleSystem particles;

	public float thrust;
	public float max_time;
	private float remaining_time;
	public float Remaining_time
	{
		get { return remaining_time; }
	}

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
		particles = GetComponentInChildren<ParticleSystem>();
		remaining_time = max_time;
	}

	private void FixedUpdate()
	{
		if (firing && !spent)
		{
			rb.AddForceAtPosition(transform.TransformVector(thrust * Vector3.up), thrust_position.position);

			remaining_time -= Time.deltaTime;

			if (remaining_time < 0)
			{
				Debug.Log(name + " ran out of fuel at " + Time.time + " with remaing time: " + remaining_time + " out of: " + max_time);
				firing = false;
				spent = true;
				particles.Stop();
			}
		}
	}

	private void Fire(bool b)
	{
		if(!spent && armed && b)
		{
			firing = b;
			particles.Play();
		}
	}

}
