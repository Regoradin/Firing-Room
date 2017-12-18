using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Staging : NetworkBehaviour
{
	public List<Rigidbody> connected_bodies;
	public List<Staging> next_stages;   //every stage down the tree will be staged, but not actually break the joints.

	private List<FixedJoint> joints;
	
	[SyncVar(hook = "Stage")]
	public bool connected = true;

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
			foreach(MonoBehaviour script in GetComponentsInChildren<MonoBehaviour>())
				{
					if (!(script is NetworkIdentity))
					{
						Destroy(script);
					}
				}
			foreach(Staging staging in next_stages)
			{
				staging.Stage(true, false);
			}
		}
	}
}
