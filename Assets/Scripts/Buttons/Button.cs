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
	private bool lit = false;

	[Header("Animation Settings")]
	private Animator anim;
	public bool light_toggle;

	protected void Start()
	{
		network = GameObject.Find("Network").GetComponent<Network>();

		rend = GetComponent<Renderer>();
		mat = rend.material;
		mat.SetColor("_EmissionColor", unlit_color);
		light = GetComponentInChildren<Light>();
		light.color = unlit_color;

		anim = GetComponent<Animator>();
	}

	protected void OnMouseDown()
	{
		anim.SetTrigger("ButtonPressed");
	}

	private void ClickEvent()
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
		mat.SetColor("_EmissionColor", lit_color);
		light.color = lit_color;
	}
	public void Unlight()
	{
		lit = false;
		mat.SetColor("_EmissionColor", unlit_color);
		light.color = unlit_color;

	}
}
