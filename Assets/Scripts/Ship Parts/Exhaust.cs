using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour {

	//[HideInInspector]
	public bool on;
	public float damage;

	private void OnTriggerStay(Collider other)
	{
		if (on)
		{
			foreach (ShipPart part in other.GetComponents<ShipPart>())
			{
				Debug.Log(part.name);
				part.TakeDamage(damage);
			}
		}
	}


}
