using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilledDisplay : FloatDisplay
{
	private float max_scale;
	private float midpoint;

	private void Start()
	{
		max_scale = transform.localScale.x;
		midpoint = transform.position.x;
	}

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

		float new_scale = level * max_scale;
		float new_midpoint = midpoint - max_scale/2 + new_scale/2;

		transform.localScale = new Vector3(new_scale, transform.localScale.y, transform.localScale.z);
		transform.position = new Vector3(new_midpoint, transform.position.y, transform.position.z);

		if (level == 0)
		{
			GetComponent<Renderer>().enabled = false;
		}
		else
		{
			GetComponent<Renderer>().enabled = true;
		}

	}

}
