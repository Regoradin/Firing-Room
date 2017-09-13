using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Staging : NetworkBehaviour
{
	public List<Rigidbody> connected_bodies;

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

	private void Stage(bool b)
	{
		if (!b)
		{
			foreach(FixedJoint joint in joints)
			{
				//breaking the joints
				Destroy(joint);
				foreach(MonoBehaviour script in GetComponentsInChildren<MonoBehaviour>())
				{
					//cleans off ship parts.
					if(script is IStageable)
					{
						IStageable stage_script = (IStageable) script;
						stage_script.Stage();
					}
					else
					{
						Destroy(script);
					}
				}
			}
		}
	}
}
