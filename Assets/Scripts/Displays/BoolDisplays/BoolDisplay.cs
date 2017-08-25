using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class BoolDisplay : NetworkBehaviour {

	[HideInInspector]
	[SyncVar(hook = "SetState")]
	public bool state;

	protected abstract void SetState(bool new_state);

}
