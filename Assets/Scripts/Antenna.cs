using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Antenna : NetworkBehaviour {

	public SyncListFloat target
	{
		set
		{
			SetTarget(value);
		}
	}
	

	public float latitude, longitude, altitude;
	public float range_latitude, range_longitude;
	public float max_altitude;

	public bool is_moving;
	public int channels;

	public bool is_home_antenna;
	public bool is_ship_antenna;

	private AntennaManager manager;
	[HideInInspector]
	public Antenna connected_ant;

	public float delay_multiplier = 1f;

	private void SetTarget(SyncListFloat target)
	{
		Debug.Log("sETTING TARGET");
		Target(target[0], target[1], target[2]);
	}

	private void Awake()
	{
		target = new SyncListFloat();
		//Eventually have some way to figure all this out... or fake it.
		latitude = 1f;
		longitude = 1f;
		altitude = 1f;
	}

	private void Start()
	{
		manager = GetComponentInParent<AntennaManager>();

		manager.RegisterAntenna(this);
	}

	private void Update()
	{
		if (is_moving)
		{
			//Update position stuff here however you are going to do that.
		}
	}


	/// <summary>
	/// Calculates the delay between this antenna and the one that it is connected to, currently based purely off of distance with a modifier from both antennas factored in
	/// </summary>
	/// <returns></returns>
	public float CalculateLinkDelay()
	{
		float delay = Vector3.Distance(transform.position, connected_ant.transform.position) * delay_multiplier * connected_ant.delay_multiplier;
		return delay;
	}

	/// <summary>
	/// Turns the antenna to a specified position and connects it to another antenna if one exists there. If not, disconnects it.
	/// </summary>
	/// <param name="target_latitude"></param>
	/// <param name="target_longitude"></param>
	/// <param name="target_altitude"></param>
	public void Target(float target_latitude, float target_longitude, float target_altitude)
	{
		//Currently this will instantly switch antenna target, it might be worth it to add some sort of travel time
		connected_ant = TryConnect(target_latitude, target_longitude, target_altitude);
		manager.CalculateDelay();
	}

	/// <summary>
	/// Returns an antenna at a specified location if one exists.
	/// </summary>
	/// <param name="target_latitude"></param>
	/// <param name="target_longitude"></param>
	/// <param name="target_altitude"></param>
	/// <returns></returns>
	private Antenna TryConnect(float target_latitude, float target_longitude, float target_altitude)
	{
		if(CheckInRange(target_latitude, target_longitude, target_altitude))
		{
			return manager.TryConnect(target_latitude, target_longitude, target_altitude, this);
		}
		return null;
	}

	/// <summary>
	/// Checks if a given location is in range.
	/// </summary>
	/// <param name="target_latitude"></param>
	/// <param name="target_longitude"></param>
	/// <param name="target_altitude"></param>
	/// <returns></returns>
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
