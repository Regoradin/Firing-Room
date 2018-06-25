using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Dial : NetworkBehaviour {

	public float scroll_increment;

	public float value_increment;
	public float min_value;
    public float max_value;
    public bool wrap;

    public List<Text> texts;

    [SyncVar]
	private float value;
	public float Value { get { return value; } }

    private void Start()
    {
        foreach(Text text in texts)
        {
            text.text = value.ToString();
        }
    }

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

        foreach(Text text in texts)
        {
            text.text = value.ToString();
        }
	}

	//Rotates around the local Y axis
	protected void ScrollUp(float scroll_amount)
	{
		transform.Rotate(Vector3.up * scroll_increment);
		value += value_increment;
        if (value > max_value)
        {
            value = wrap ? value - max_value + min_value - value_increment : max_value;
        }
	}

	protected void ScrollDown(float scroll_amount)
	{
		transform.Rotate(Vector3.up * -scroll_increment);
		value -= value_increment;
		if (value < min_value)
		{
            value = wrap ? value + max_value - min_value + value_increment: min_value;
		}
	}
}
