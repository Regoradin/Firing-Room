using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Button : NetworkBehaviour {

	protected Network network;

	[Header("Task Settings")]
	public string category;
	public float size = 1;
	public bool send_to_consoles = false;
	public int channels = 1;

	private Renderer rend;
	private Material mat;
	new private Light light;

	[Header("Glow Settings")]
	[ColorUsage(true, true, 0f, 8,.125f, 3f)]
	public Color unlit_color;
	[ColorUsage(true, true, 0f, 8, .125f, 3f)]
	public Color lit_color;
	[ColorUsage(true, true, 0f, 8, .125f, 3f)]
	public Color button_unlit_color;
	private bool lit = false;

	[Header("Animation Settings")]
	private Animator anim;
	public bool light_toggle;

	protected void Start()
	{
		network = GameObject.Find("Network").GetComponent<Network>();

		rend = GetComponent<Renderer>();
		mat = rend.material;
		light = GetComponentInChildren<Light>();
		anim = GetComponent<Animator>();

		Unlight();
	}

	protected void OnMouseDown()
	{
		//Because NetworkAnimators are weird with triggers.
		GetComponent<NetworkAnimator>().SetTrigger("ButtonPressed");
	}

	protected void ClickEvent()
	{
		if (light_toggle)
		{
			if (lit)
			{
				Unlight();
			}
			else
			{
				Light();
			}
		}
	}

	public void Light()
	{
		lit = true;
		mat.color = lit_color;
		mat.SetColor("_EmissionColor", lit_color);
		light.color = lit_color;
	}
	public void Unlight()
	{
		lit = false;
		mat.color = button_unlit_color;
		mat.SetColor("_EmissionColor", unlit_color);
		light.color = unlit_color;
	}
}
