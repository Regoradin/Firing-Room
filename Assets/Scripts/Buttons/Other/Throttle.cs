﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Throttle : NetworkBehaviour {

	private Network network;
	private Animator anim;

	[Header("Task Settings")]
	public MonoBehaviour target_behaviour;
	private IFloatTaskable target;
	public string category;
	public float size = 1;
	public bool send_to_consoles = false;
	public int channels = 1;

	[Header("Throttle Settings")]
	public bool is_horizontal = false;
	public bool is_backwards = false;	//i.e. does it increase to the bottom or to the left
	public float max_value = 1;
	public float min_value = 0;
	public float sensitivity = 1;

	private float level = 0;
	private float last_mouse_position;

	private void Awake()
	{
		network = GameObject.Find("Network").GetComponent<Network>();
		target = target_behaviour as IFloatTaskable;
		anim = GetComponent<Animator>();
	}

	private void OnMouseDown()
	{
		if (is_horizontal)
		{
			last_mouse_position = Input.mousePosition.x;
		}
		else
		{
			last_mouse_position = Input.mousePosition.y;
		}
	}

	private void OnMouseDrag()
	{
		//sets level appropriately
		float new_mouse_position = 0;
		if (is_horizontal)
		{
			new_mouse_position = Input.mousePosition.x;
		}
		else
		{
			new_mouse_position = Input.mousePosition.y;
		}
		if (is_backwards)
		{
			if (new_mouse_position > last_mouse_position)
			{
				level -= sensitivity;
			}
			if (new_mouse_position < last_mouse_position)
			{
				level += sensitivity;
			}
		}
		else
		{
			if (new_mouse_position < last_mouse_position)
			{
				level -= sensitivity;
			}
			if (new_mouse_position > last_mouse_position)
			{
				level += sensitivity;
			}
		}
		if (is_horizontal)
		{
			last_mouse_position = Input.mousePosition.x;
		}
		else
		{
			last_mouse_position = Input.mousePosition.y;
		}

		anim.SetFloat("Level", level);
	}

	private void OnMouseUp()
	{
		network.AddTask(new FloatTask(target, level, category, size, send_to_consoles, channels));
	}


}
