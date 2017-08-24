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
		Debug.Log("current thrust: " + current_thrust);
		rb.AddForce(Vector3.up * current_thrust);
	}

	public void SetThrust(float level)
	{
		current_thrust = max_thrust * level;
	}

}
