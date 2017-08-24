using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatLongAltFinder : MonoBehaviour {

	private void Update()
	{
		Debug.Log(LatLongAlt.FindLatLongAlt(transform));
	}

}
