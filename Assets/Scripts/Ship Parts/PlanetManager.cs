using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour {

	public Planet planet;
	public Planet default_planet;

	public List<Rigidbody> rbs;


	public void Start()
	{
		planet = default_planet;
	}

	public void Update()
	{
		foreach (Rigidbody rb in rbs)
		{
			rb.AddForce(Gravity());
		}
	}

	public Vector3 Gravity()
	{
		float grav_constant = 1000;

		Vector3 direction = (planet.transform.position - transform.position).normalized;
		float radius = Vector3.Distance(planet.transform.position, transform.position);


		float mass = 0;
		foreach (Rigidbody rb in rbs)
		{
			mass += rb.mass;
		}

		Vector3 directed_force = direction * (grav_constant * (planet.GetComponent<Rigidbody>().mass) * (mass)) / (radius * radius);

		return directed_force;
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

	/// <summary>
	/// Return the air density at the position of the planet manager in the current SoI, which should be the planet you are near. Returns NaN if you are outside the range of the atmosphere.
	/// </summary>
	/// <returns></returns>
	public float AirDensity()
	{
		float density = Mathf.Pow((1 - (1 / planet.atmos_max_radius) * LatLongAlt().z), planet.atmos_dropoff_rate);

		return density;
	}

}
