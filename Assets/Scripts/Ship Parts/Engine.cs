using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Engine : NetworkBehaviour {

	private Rigidbody rb;
	public float max_thrust;
	private float current_thrust = 0;
	private float target_thrust;

	public float thrust_increment;

	[HideInInspector]
	[SyncVar(hook = "SetThrust")]
	public float level;

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
}	

	private void FixedUpdate()
	{
		if(Mathf.Abs(current_thrust - target_thrust) <= thrust_increment)
		{
			current_thrust = target_thrust;
		}

		if(!Mathf.Approximately(current_thrust, target_thrust))
		{
			if(current_thrust > target_thrust)
			{
				current_thrust -= thrust_increment;
			}
			else
			{
				current_thrust += thrust_increment;
			}
		}

		rb.AddForce(Vector3.up * current_thrust);
	}

	public void SetThrust(float new_level)
	{
		level = new_level;
		target_thrust = max_thrust * new_level;
	}

}
