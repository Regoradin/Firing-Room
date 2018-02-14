using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecimalDisplay : FloatDisplay{

	public Text text;

	protected override void SetLevel(float new_level)
	{
		Debug.Log("Setting level");
		level = new_level;

		text.text = level.ToString();
	}
}
