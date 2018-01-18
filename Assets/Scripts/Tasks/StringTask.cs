using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTask : Task {

	private IStringTaskable target;
	private string s;

	public StringTask(IStringTaskable target, string s, string category, float size, bool send_to_consoles = false, int channels = 1):base(category, s, send_to_consoles, channels)
	{
		this.target = target;
		this.s = s;
	}

	public override void Activate()
	{
		target.StringTask(s);
	}

}
