using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Staging : NetworkBehaviour
{
	public List<Rigidbody> connected_bodies;
	public List<Staging> next_stages;   //every stage down the tree will be staged, but not actually brake the joints.

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

	public void Stage(bool b)
	{
		Debug.Log("stage");
		connected = b;
		if (!connected)
		{
			foreach(FixedJoint joint in joints)
			{
				//breaking the joints
				Destroy(joint);
				foreach(MonoBehaviour script in GetComponentsInChildren<MonoBehaviour>())
				{
					if (!(script is NetworkIdentity))
					{
						Destroy(script);
					}
				}
			}
			
			foreach(Staging staging in next_stages)
			{
				staging.FakeStage(false);
			}
		}
	}

	public void FakeStage(bool b)
	{
		//like a normal stage, but doesn't break the joints
		connected = b;
		if (!connected)
		{
			foreach (MonoBehaviour script in GetComponentsInChildren<MonoBehaviour>())
			{
				if (!(script is NetworkIdentity))
				{
					Destroy(script);
				}
			}
			foreach (Staging staging in next_stages)
			{
				staging.FakeStage(false);
			}
		}
	}
		
	

}
