using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VelocityReporter : Reporter, ITriggerTaskable {

	public List<FloatDisplay> displays;

	private Rigidbody rb;

	private Rigidbody reference_rb;  //the rigidbody that has the reference 0 velocity;
	public Rigidbody reference_rb_t;
	public Rigidbody reference_rb_f;
	[SyncVar(hook = "SetReference")]
	public bool rb_choice = true;

	private void SetReference(bool b)
	{
		rb_choice = b;
		reference_rb = rb_choice ? reference_rb_t : reference_rb_f;
	}
	public void TriggerTask()
	{
		rb_choice = !rb_choice;
	}



	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	protected override void RpcReport()
	{

		float calculated_velocity = rb.velocity.magnitude;
		if(reference_rb != null)
		{
			calculated_velocity = (rb.velocity - reference_rb.velocity).magnitude;
		}

		network.AddData(new FloatData(displays, calculated_velocity, "Guidance", .1f));
	}

}
