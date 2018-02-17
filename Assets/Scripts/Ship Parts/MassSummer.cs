using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassSummer : MonoBehaviour {

	void Awake () {
		Debug.Log("Setting mass");
		Rigidbody rb = GetComponent<Rigidbody>();
		float mass = 0;
		foreach(ShipPart part in GetComponentsInChildren<ShipPart>())
		{
			mass += part.mass;
		}
		rb.mass = mass;
	}
}
