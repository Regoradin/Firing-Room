using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeViewer : MonoBehaviour {

	private Text text;
	public Network network;

	void Start () {
		text = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = network.debug_message;
	}
}
