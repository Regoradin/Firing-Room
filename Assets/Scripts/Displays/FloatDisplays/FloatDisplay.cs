using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class FloatDisplay : NetworkBehaviour {

	[HideInInspector]
	[SyncVar(hook = "SetLevel")]
	public float level;

	protected abstract void SetLevel(float new_level);
}
