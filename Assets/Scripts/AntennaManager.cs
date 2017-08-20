using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaManager : MonoBehaviour {

	private List<Antenna> antennas;
	private List<Antenna> home_antennas;
	private List<Antenna> ship_antennas;

	public Network network;

	public float acceptable_error;


	private void Awake()
	{
		antennas = new List<Antenna>();
		home_antennas = new List<Antenna>();
		ship_antennas = new List<Antenna>();
	}

	public void RegisterAntenna(Antenna antenna)
	{
		antennas.Add(antenna);
		if (antenna.is_home_antenna)
		{
			home_antennas.Add(antenna);
		}
		if (antenna.is_ship_antenna)
		{
			ship_antennas.Add(antenna);
		}
	}

	/// <summary>
	/// Calculates the delay between home and ship, and sets the network accordingly.
	/// </summary>
	public void CalculateDelay()
	{
		Debug.Log("Got to here");
		List<float> possible_path_delays = new List<float>();

		//assembles a list of the delays from each complete path from a home antenna to the ship
		Debug.Log("homeant count " + home_antennas.Count);
		foreach (Antenna home_ant in home_antennas)
		{
			float path_delay = 0f;
			Antenna act_ant = home_ant;

			while (act_ant.connected_ant != null && !act_ant.connected_ant.is_home_antenna)
			{
				path_delay += act_ant.CalculateLinkDelay();
			}
			if (act_ant.is_ship_antenna)
			{
				possible_path_delays.Add(path_delay);
			}
		}
		Debug.Log("point 1");
		//finds the shortest one and sets that as the delay
		if(possible_path_delays.Count == 0)
		{
			network.delay = -1f;
		}
		else
		{
			float shortest = possible_path_delays[0];
			foreach(float path in possible_path_delays)
			{
				if(path < shortest)
				{
					shortest = path;
				}
			}
			network.delay = shortest;
		}
		Debug.Log("Calculated delay to be " + network.delay);

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
