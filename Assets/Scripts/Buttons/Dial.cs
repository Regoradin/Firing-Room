using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : MonoBehaviour {

	public float scroll_increment;

	public float value_increment;
	public float max_value;
	public float min_value;

	private float value;
	public float Value { get { return value; } }

	private void OnMouseOver()
	{
		float scroll_amount = Input.GetAxis("Mouse ScrollWheel");

		if (scroll_amount > 0)
		{
			ScrollUp(scroll_amount);
		}
		if (scroll_amount < 0)
		{
			ScrollDown(scroll_amount);
		}
	}

	//Rotates around the local Y axis
	protected void ScrollUp(float scroll_amount)
	{
		transform.Rotate(Vector3.up * scroll_increment);
		value += value_increment;
		if (value >= max_value)
		{
			value = max_value;
		}
	}

	protected void ScrollDown(float scroll_amount)
	{
		transform.Rotate(Vector3.up * -scroll_increment);
		value -= value_increment;
		if (value <= min_value)
		{
			value = min_value;
		}
	}
}
