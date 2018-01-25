using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericScience : Reporter, ITriggerTaskable, IIntTaskable {

	public bool[] state;
	private bool[][] successes;
	private bool[][] fails;

	[Header("The length of these are the number of possible successes or fails.")]
	[Header("They should only be 1s or 0s with length == the length of state")]
	//This allows the success and fail states to be changed in the inspector
	public string[] success_strings;
	public string[] fail_strings;

	private bool broken = false;

	public void TriggerTask()
	{
		if (isServer)
		{
			Report();
		}
	}

	public void IntTask(int i)
	{
		state[i] = !state[i];
	}

	private void Update()
	{
		//This is necessary to stop incremental reports;
	}

	private void Awake()
	{
		successes = ArraySetup(success_strings);
		fails = ArraySetup(fail_strings);
	}


	private bool[][] ArraySetup(string[] input)
	{
		bool[][] output = new bool[input.Length][];

		for (int s = 0; s < input.Length; s++)
		{
			output[s] = new bool[input[s].Length];
			for (int c = 0; c < input[s].Length; c++)
			{
				if (input[s][c] == '1')
				{
					output[s][c] = true;
				}
				else
				{
					output[s][c] = false;
				}
			}
		}

		return output;
	}


	protected override void Report()
	{
		if (!broken)
		{
			foreach(bool[] fail in fails)
			{
				if (ArrayCompare(state, fail)) {
					broken = true;
					Debug.Log("Science broke");
				}
			}
			foreach (bool[] success in successes)
			{
				if (ArrayCompare(state, success))
				{
					network.AddData(new DebugData("Science", "Debug", 2));
				}
			}

		}
	}

	private bool ArrayCompare(bool[] array1, bool[] array2)
	{
		if(array1.Length != array2.Length)
		{
			return false;
		}
		else
		{
			for(int i = 0; i < array1.Length; i++)
			{
				if(array1[i] != array2[i])
				{
					return false;
				}
			}
			return true;
		}
	}
}
