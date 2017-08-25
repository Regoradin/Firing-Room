using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Engine : NetworkBehaviour {

	private Rigidbody rb;
	public float max_thrust;
	private float current_thrust = 0;

	[SyncVar(hook = "SetThrust")]
	public float level;

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		rb.AddForce(Vector3.up * current_thrust);
	}

	public void SetThrust(float new_level)
	{
		level = new_level;
		current_thrust = max_thrust * new_level;
	}

}
