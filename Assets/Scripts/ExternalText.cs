using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExternalText : MonoBehaviour {

	private Text ui_text;
	public TextAsset text;

	private void Awake()
	{
		ui_text = GetComponent<Text>();

		if (text)
		{
			ui_text.text = text.text;
		}
		else
		{
			ui_text.text = "Text not assigned";
		}
	}

}
