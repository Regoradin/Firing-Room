using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShipPart : NetworkBehaviour {

	public float max_health;
	private float health;

	private Collider coll;

	private void Awake()
	{
		coll = GetComponentInParent<Collider>();
		coll.OnCollision
	}

	public virtual void TakeDamage(float damage)
	{
		health -= damage;
	}

}
