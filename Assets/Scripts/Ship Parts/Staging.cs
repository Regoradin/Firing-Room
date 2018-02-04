using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Staging : NetworkBehaviour, ITriggerTaskable
{
	//Alright so the way this is supposed to work is that the next_stages and connected_bodies are the stages below it. You call staging on this when it should be used.

	public List<Rigidbody> connected_bodies;
	public List<Staging> next_stages;   //every stage down the tree will be staged, but not actually break the joints.

	private List<FixedJoint> joints;
	
	[SyncVar(hook = "HookStage")]
	private bool connected = true;
	public void TriggerTask()
	{
		connected = false;
	}

	/// <summary>
	/// this only exists to deal with that pesky optional bool that apparently breaks the function signature.
	/// </summary>
	public void HookStage(bool b)
	{
		Stage(false);
	}


	void Awake()
	{
		joints = new List<FixedJoint>();
	}

	public override void OnStartClient()
	{
		foreach (Rigidbody rb in connected_bodies)
		{
			FixedJoint joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = rb;
			joints.Add(joint);
		}

	}

	public void Stage(bool b, bool breaking = true)
	{
		Debug.Log("stage: " + name);
		connected = b;
		if (!connected)
		{
			if (breaking)
			{
				foreach (FixedJoint joint in joints)
				{
					//breaking the joints
					Destroy(joint);
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
