using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShipPart : NetworkBehaviour {

	public float max_health = 1;
	private float health;
	public float Health
	{
		get { return health; }
	}

	public float mass;

	protected virtual void Awake()
	{
		health = max_health;
	}

	private void OnTriggerEnter(Collider other)
	{
		Rigidbody rb = other.GetComponent<Rigidbody>();
		float damage = rb.velocity.magnitude * rb.mass; //maybe make this more realistic at some point in some way.

		//damage = 1;

		Debug.Log(name + "with " + health + " health remaining was damaged by " + other.name + " doing " + damage + " damage");
		TakeDamage(damage);
	}

	public virtual void TakeDamage(float damage)
	{
		health -= damage;
		if(health <= 0)
		{
			Die();
		}
	}

	public virtual void Die()
	{
		Debug.Log(name + " died");
		Destroy(this);
	}

}
