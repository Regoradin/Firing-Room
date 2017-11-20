using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	public float atmos_max_radius;
	public float atmos_dropoff_rate;

	private static float sea_level_radius;
	private SphereCollider influence_collider;

	//this is the larger body that this orbits around
	public GameObject parent_body;

	public void Activate()
	{
		//This calculates the distance from the center of the planet to the most distant point along the x axis, which will be defined as sea level
		sea_level_radius = GetComponent<Collider>().bounds.extents.x;

		if (parent_body != null)
		{
			influence_collider = gameObject.AddComponent<SphereCollider>();
			influence_collider.isTrigger = true;

			influence_collider.radius = Mathf.Pow((transform.position - parent_body.transform.position).magnitude * (GetComponent<Rigidbody>().mass / parent_body.GetComponent<Rigidbody>().mass), 2 / 5);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		PlanetaryInfo.planet = gameObject;
	}

	public void OnTriggerExit(Collider other)
	{
		PlanetaryInfo.planet = PlanetaryInfo.default_planet;
	}

}
