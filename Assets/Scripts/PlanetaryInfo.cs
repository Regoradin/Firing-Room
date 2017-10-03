using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlanetaryInfo {

	private static GameObject planet;
	private static float sea_level_radius;

	static PlanetaryInfo()
	{
		GameObject[] possible_planets = GameObject.FindGameObjectsWithTag("Planet");
		if (possible_planets.Length == 0)
		{
			Debug.Log("There are no planets in this scene!");
		}
		else
		{
			if (possible_planets.Length > 1)
			{
				Debug.Log("There are multiple planets in this scene!");
			}
			planet = possible_planets[0];
		}

		//This calculates the distance from the center of the planet to the most distant point along the x axis, which will be defined as sea level
		sea_level_radius = planet.GetComponent<Collider>().bounds.extents.x;
	}

	public static Vector3 LatLongAlt(Transform transform)
	{
		float altitude = Vector3.Distance(transform.position, planet.transform.position);
		altitude -= sea_level_radius;

		float x_dist = transform.position.x - planet.transform.position.x;
		float y_dist = transform.position.y - planet.transform.position.y;
		float z_dist = transform.position.z - planet.transform.position.z;

		float latitude = Mathf.Rad2Deg * Mathf.Atan2(y_dist, Mathf.Sqrt((x_dist * x_dist) + (z_dist * z_dist)));
		float longitude = Mathf.Rad2Deg * Mathf.Atan2(z_dist, Mathf.Sqrt((x_dist * x_dist) + (y_dist * y_dist)));

		if (x_dist < 0)
		{
			if(z_dist >= 0)
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

	public static float AirDensity(Transform transform)
	{
		//add actual calculations
		return 1.229f;
	}

}
