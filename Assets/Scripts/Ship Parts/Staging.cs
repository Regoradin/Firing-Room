using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Staging : NetworkBehaviour, ITriggerTaskable
{
	//Alright so the way this is supposed to work is that the next_stages and connected_bodies are the stages below it. You call staging on this when it should be used.

	public List<GameObject> connected_bodies;
	public List<Staging> next_stages;   //every stage down the tree will be staged, but not actually break the joints.

	
	[SyncVar(hook = "HookStage")]
	public bool connected = true;
	public void TriggerTask()
	{
		connected = false;
	}

	/// <summary>
	/// this only exists to deal with that pesky optional bool that apparently breaks the function signature.
	/// </summary>
	private void HookStage(bool b)
	{
		Stage(false);
	}

    private void Stage(bool b, bool breaking = true)
	{
        Debug.Log("Staging: " + name);
		connected = b;
		if (!connected)
		{
			if (breaking)
			{
				foreach(GameObject connected in connected_bodies)
				{
					connected.transform.parent = null;
					Rigidbody rb = connected.AddComponent<Rigidbody>();
					float mass = 0;
					foreach(ShipPart part in connected.GetComponentsInChildren<ShipPart>())
					{
						mass += part.mass;
					}
					rb.mass = mass;
					rb.useGravity = false;
					rb.angularDrag = 0;
				}
			}
			foreach (Staging stage in next_stages)
			{
				foreach (MonoBehaviour script in stage.GetComponentsInChildren<MonoBehaviour>())
				{
					Debug.Log(script.name + stage.gameObject.name);
					if (!(script is NetworkIdentity) && !(script is Staging))
					{
						Destroy(script);
					}
				}
			}
			foreach (Staging staging in next_stages)
			{
				staging.Stage(true, false);
			}
		}
	}

}
