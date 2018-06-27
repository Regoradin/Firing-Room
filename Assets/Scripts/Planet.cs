using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	public float atmos_max_radius;
	public float atmos_dropoff_rate;

	[HideInInspector]
	public float sea_level_radius;
	private SphereCollider influence_collider;

	//this is the larger body that this orbits around
	public GameObject parent_body;

	public void Awake()
	{
		//This calculates the distance from the center of the planet to the most distant point along the x axis, which will be defined as sea level
		sea_level_radius = GetComponent<Collider>().bounds.extents.x;

		//the only bodies that don't get a SoI should be the biggest parent planets
		if (parent_body != null)
		{
			influence_collider = gameObject.AddComponent<SphereCollider>();
			influence_collider.isTrigger = true;

			float soi_radius = Mathf.Pow((transform.position - parent_body.transform.position).magnitude * (GetComponent<Rigidbody>().mass / parent_body.GetComponent<Rigidbody>().mass), (2f / 5f));
			influence_collider.radius = soi_radius;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		other.GetComponent<PlanetManager>().Planet = this;
	}

	public void OnTriggerExit(Collider other)
	{
		other.GetComponent<PlanetManager>().Planet = parent_body.GetComponent<Planet>() ;
	}

}
