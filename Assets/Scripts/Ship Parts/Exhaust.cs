using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour {

	//[HideInInspector]
	public bool on;
	public float damage;

	private ShipPart[] parts;

	private void Start()
	{
		CheckParts();
	}

	private void CheckParts()
	{
		parts = FindObjectsOfType<ShipPart>();
	}

	private void Update()
	{
		if (on)
		{
			Bounds bounds = GetComponent<Collider>().bounds;
			bool recheck = false;

			foreach (ShipPart part in parts)
			{
				if (part.GetComponent<Collider>().bounds.Intersects(bounds))
				{
					if (part.Health <= damage)
					{
						recheck = true;
					}
					part.TakeDamage(damage);
				}


			}
			if (recheck)
			{
				//this is invoked in order to allow any killed parts to actually die and also to create any new post-death parts
				Invoke("CheckParts", .1f);
			}

		}
	}

}
