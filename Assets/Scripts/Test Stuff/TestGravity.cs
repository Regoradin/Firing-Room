using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGravity : MonoBehaviour {

	public GameObject gravitied;
	public float grav_constant;

	private void FixedUpdate()
	{
		Vector3 direction = (transform.position - gravitied.transform.position).normalized;
		float radius = Vector3.Distance(transform.position, gravitied.transform.position);
		

		Vector3 directed_force = direction * (grav_constant * (gameObject.GetComponent<Rigidbody>().mass) * (gravitied.GetComponent<Rigidbody>().mass)) / (radius * radius);

		gravitied.GetComponent<Rigidbody>().AddForce(directed_force);
	}

}
