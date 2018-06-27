using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour {

	private Planet planet;
	public Planet Planet
	{
		get { return planet; }
		set
		{
			planet = value;
			planet_zone_manager = planet.GetComponent<ZoneManager>();
		}
	}
	private ZoneManager planet_zone_manager;
    private ZoneManager zone_manager;
	public Planet default_planet;

	public List<Rigidbody> rbs;


	public void Start()
	{
		planet = default_planet;
        planet_zone_manager = planet.GetComponent<ZoneManager>();
        zone_manager = GetComponent<ZoneManager>();
	}

	public void Update()
	{
		foreach (Rigidbody rb in rbs)
		{
			rb.AddForce(Gravity());
		}
	}

    private Vector3 RealPosition()
    {
        if (zone_manager.is_focus)
        {
            Vector3 real_pos = zone_manager.zone_width * zone_manager.zone_pos + transform.position;
            return real_pos;
        }
        else
        {
            Vector3 real_pos = zone_manager.zone_width * zone_manager.zone_pos + zone_manager.remainder_pos;
            return real_pos;
        }
    }
    private Vector3 RealPlanetPosition()
    {
        Vector3 real_pos = planet_zone_manager.zone_width * planet_zone_manager.zone_pos + planet_zone_manager.remainder_pos;
        return real_pos;
    }

	public Vector3 Gravity()
	{
		float grav_constant = 1000;

        Vector3 position = RealPosition();
        Vector3 planet_pos = RealPlanetPosition();

		Vector3 direction = (planet_pos - position).normalized;
		float radius = Vector3.Distance(planet_pos, position);


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
        Vector3 position = RealPosition();
        Vector3 planet_pos = RealPlanetPosition();

        float altitude = Vector3.Distance(position, planet_pos);
		altitude -= planet.sea_level_radius;

		float x_dist = position.x - planet_pos.x;
		float y_dist = position.y - planet_pos.y;
		float z_dist = position.z - planet_pos.z;

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
