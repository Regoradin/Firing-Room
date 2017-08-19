using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaManager : MonoBehaviour {

	private List<Antenna> antennas;
	public float acceptable_error;

	private void Awake()
	{
		antennas = new List<Antenna>();
	}

	public void RegisterAntenna(Antenna antenna)
	{
		antennas.Add(antenna);
	}

	public Antenna TryConnect(float target_latitude, float target_longitude, float target_altitude, Antenna connecting_ant)
	{
		foreach(Antenna ant in antennas)
		{
			if (ant.latitude <= target_latitude + acceptable_error && ant.latitude >= target_latitude - acceptable_error)
			{
				if(ant.longitude <= target_longitude + acceptable_error && ant.longitude >= target_longitude - acceptable_error)
				{
					if(ant.altitude <= target_altitude + acceptable_error && ant.altitude >= target_altitude - acceptable_error)
					{
						if(ant.CheckInRange(connecting_ant.latitude, connecting_ant.longitude, connecting_ant.altitude))
						{
							return ant;
						}
					}
				}
			}
		}

		return null;
	}

}
