using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MeterDisplay : FloatDisplay
{
	private float min_movement;
	public float max_movement;
	private float range;

	protected override void SetLevel(float new_level)
	{
		if (new_level > 1)
		{
			level = 1;
			Debug.Log("Trying to set level above 1");
		}
		else if (new_level < 0)
		{
			level = 0;
			Debug.Log("Trying to set level below 0");
		}
		else
		{
			level = new_level;
		}

		transform.localPosition = new Vector3(min_movement + (range * level), transform.localPosition.y, transform.localPosition.z);
	}

	private void Start()
	{
		min_movement = transform.localPosition.x;
		range = max_movement - min_movement;
	}
}