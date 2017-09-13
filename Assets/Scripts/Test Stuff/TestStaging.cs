using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestStaging : NetworkBehaviour {

	private Rigidbody rb;
	public Rigidbody connected_body;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public override void OnStartClient()
	{
		Debug.Log("Connecting Client");
		FixedJoint joint = gameObject.AddComponent<FixedJoint>();
		joint.connectedBody = connected_body;

		rb.AddForce(Vector3.up * 20);

	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
