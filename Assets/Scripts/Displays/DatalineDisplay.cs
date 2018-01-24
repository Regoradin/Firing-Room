using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DatalineDisplay : NetworkBehaviour{

	public Dataline dataline;

	public GameObject block;

	public Transform start;
	public Transform end;

	[Header("Category Colors")]
	public Color default_color;
	//this is a temporary way to make it show up in the inspector
	public List<string> categories;
	public List<Color> colors;
	private Dictionary<string, Color> cat_colors;

	private void Start()
	{
		cat_colors = new Dictionary<string, Color>();

		if(categories.Count == colors.Count)
		{
			for(int i = 0; i < categories.Count; i++)
			{
				cat_colors[categories[i]] = colors[i];
			}
		}

		dataline.EventTaskUploaded += UnpackTask;
		dataline.EventDataDownloaded += UnpackData;
	}

	private void UnpackTask(Task task)
	{
		if (isServer)
		{
			RpcTaskUpload(task.size, task.category);
		}
	}

	[ClientRpc]
	private void RpcTaskUpload(float size, string category)
	{
		//Math to make the next three things work
		float adjustment = (-Vector3.Distance(start.position, end.position) * size) / (2 * (size - dataline.Network.delay));
		float speed = (-Vector3.Distance(start.position, end.position)) / (size - dataline.Network.delay);

		Vector3 direction = (end.position - start.position).normalized;

		//Makes a new block behind the starting position with the same rotation as the parent object
		Vector3 starting_position = start.position - (direction * adjustment);
		GameObject new_block = Instantiate(block, starting_position, transform.rotation);

		//Makes the block go
		Vector3 velocity = direction.normalized * speed;
		new_block.GetComponent<Rigidbody>().velocity = velocity;
	
		//Makes the block appropriately skinny
		new_block.transform.localScale = new Vector3(new_block.transform.localScale.x, new_block.transform.localScale.y, adjustment * 2);

		//Makes the block appropriately pretty
		Material mat = new_block.GetComponent<Renderer>().material;
		if (cat_colors.ContainsKey(category))
		{
			mat.SetColor("_Color", cat_colors[category]);
		}
		else
		{
			mat.SetColor("_Color", default_color);
		}


		Destroy(new_block, dataline.Network.delay);
	}
	
	private void UnpackData(Data data)
	{
		RpcDataDownload(data.size, data.category);
	}

	[ClientRpc]
	private void RpcDataDownload(float size, string category)
	{
		//making sure it doesn't divide by 0. This needs to get worked out to make sure the adjustment is right, and make sure it doesn't go backwards ever, and make sure this is done for the other direction
		if(size == dataline.Network.delay)
		{
			size -= .1f;
		}

		//Math to make the next three things work
		float adjustment = (-Vector3.Distance(start.position, end.position) * size) / (2 * (size - dataline.Network.delay));
		float speed = (-Vector3.Distance(start.position, end.position)) / (size - dataline.Network.delay);

		Vector3 direction = (start.position - end.position).normalized;

		//Makes a new block behind the starting position with the same rotation as the parent object
		Vector3 starting_position = end.position + (direction * adjustment);
		GameObject new_block = Instantiate(block, starting_position, transform.rotation);

		//Makes the block go
		Vector3 velocity = direction.normalized * speed;
		new_block.GetComponent<Rigidbody>().velocity = velocity;

		//Makes the block appropriately skinny
		new_block.transform.localScale = new Vector3(new_block.transform.localScale.x, new_block.transform.localScale.y, adjustment * 2);

		//Makes the block appropriately pretty
		Material mat = new_block.GetComponent<Renderer>().material;
		if (cat_colors.ContainsKey(category))
		{
			mat.SetColor("_Color", cat_colors[category]);
		}
		else
		{
			mat.SetColor("_Color", default_color);
		}


		Destroy(new_block, dataline.Network.delay);
	}
}
