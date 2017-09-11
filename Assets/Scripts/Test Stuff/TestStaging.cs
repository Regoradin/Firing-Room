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

	private void OnConnectedToServer()
	{
		Debug.Log("Connecting Client");
		FixedJoint joint = gameObject.AddComponent<FixedJoint>();
		joint.connectedBody = connected_body;
	}

	// Use this for initialization
	void Start () {
		rb.AddForce(Vector3.up * 20);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
