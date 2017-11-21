using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour {

	public Planet planet;
	public Planet default_planet;

	public void Start()
	{
		planet = default_planet;
	}

	public void Update()
	{
		Debug.Log(planet.name);
	}

	public Vector3 LatLongAlt()
	{
		float altitude = Vector3.Distance(transform.position, planet.transform.position);
		altitude -= planet.sea_level_radius;

		float x_dist = transform.position.x - planet.transform.position.x;
		float y_dist = transform.position.y - planet.transform.position.y;
		float z_dist = transform.position.z - planet.transform.position.z;

		float latitude = Mathf.Rad2Deg * Mathf.Atan2(y_dist, Mathf.Sqrt((x_dist * x_dist) + (z_dist * z_dist)));
		float longitude = Mathf.Rad2Deg * Mathf.Atan2(z_dist, Mathf.Sqrt((x_dist * x_dist) + (y_dist * y_dist)));

		if (x_dist < 0)
		{
			if (z_dist >= 0)
			{
				longitude = 180 - longitude;
			}
			else
			{
				longitude = -180 - longitude;
			}
		}

		return new Vector3(latitude, longitude, altitude);
	}

	public float AirDensity(Transform transform)
	{
		float max_radius = 2f;
		float dropoff_rate = .6f;

		float density = Mathf.Pow((1 - (1 / max_radius) * this.LatLongAlt().z), dropoff_rate);

		return density;
	}

}
