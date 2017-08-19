using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour {

	public float latitude, longitude, altitude;
	public float range_latitude, range_longitude;
	public float max_altitude;
	public int channels;

	private AntennaManager manager;

	private void Awake()
	{
		//Eventually have some way to figure all this out... or fake it.
		latitude = 1f;
		longitude = 1f;
		altitude = 1f;

		manager = GetComponentInParent<AntennaManager>();
	}

	private void Start()
	{
		manager.RegisterAntenna(this);
	}

	public Antenna TryConnect(float target_latitude, float target_longitude, float target_altitude)
	{
		if(CheckInRange(target_latitude, target_longitude, target_altitude))
		{
			return manager.TryConnect(target_latitude, target_longitude, target_altitude, this);
		}
		return null;
	}

	public bool CheckInRange(float target_latitude, float target_longitude, float target_altitude)
	{
		if (target_latitude <= latitude + range_latitude && target_latitude >= latitude - range_latitude)
		{
			if (target_longitude <= latitude + range_longitude && target_longitude >= longitude - range_longitude)
			{
				if(target_altitude <= max_altitude)
				{
					return true;
				}
			}
		}
		return false;
	}
}
