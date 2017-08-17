using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public Network network;

	//currently this is only for a two state switch
	private int state = 0;
	
	public void SwitchState()
	{
		if (state == 0)
		{
			state = 1;
		}

		else
		{
			state = 0;
		}
	}
}
