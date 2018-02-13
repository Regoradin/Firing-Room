using System.Collections;
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
	public bool is_backwards = false;   //i.e. does it increase to the bottom or to the left
	public bool is_mousewheel = false;
	public float max_value = 1;
	public float min_value = 0;
	public float sensitivity = 1;
	public float mouse_deadzone = 0;
	public float held_delay;

	private float level = 0;
	private float last_mouse_position;

	private float last_time = 0;
	private float last_level;

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
			if (new_mouse_position > last_mouse_position + mouse_deadzone)
			{
				level -= sensitivity;
			}
			if (new_mouse_position < last_mouse_position - mouse_deadzone)
			{
				level += sensitivity;
			}
		}
		else
		{
			if (new_mouse_position < last_mouse_position - mouse_deadzone)
			{
				level -= sensitivity;
			}
			if (new_mouse_position > last_mouse_position + mouse_deadzone)
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

		if (level > max_value)
		{
			level = max_value;
		}
		if (level < min_value)
		{
			level = min_value;
		}

		anim.SetFloat("Blend", level / (max_value - min_value));

		//sends a task if the throttle is held in place
		if (last_time + held_delay <= Time.time)
		{
			last_time = Time.time;
			if (last_level == level)
			{
				CmdAddTask();
			}
			last_level = level;
		}
	}

	private void OnMouseOver()
	{
		if (is_mousewheel)
		{
			if (is_backwards)
			{
				level -= sensitivity * Input.mouseScrollDelta.y;
			}
			else
			{
				level += sensitivity * Input.mouseScrollDelta.y;
			}

			if (level > max_value)
			{
				level = max_value;
			}
			if (level < min_value)
			{
				level = min_value;
			}

			anim.SetFloat("Blend", level / (max_value - min_value));
		}
	}

	private void OnMouseUp()
	{
		if (last_level != level)
		{
			CmdAddTask();
		}
	}

	private void OnMouseExit()
	{
		if (is_mousewheel)
		{
			CmdAddTask();
		}
	}

	[Command]
	private void CmdAddTask()
	{
		network.AddTask(new FloatTask(target, level, category, size, send_to_consoles, channels));
	}


}
