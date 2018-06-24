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
		float distance = Vector3.Distance(start.position, end.position);
		float speed = distance / dataline.Network.delay;

		Vector3 direction = (end.position - start.position).normalized;

		//Makes a new block behind the starting position with the same rotation as the parent object
		Vector3 starting_position = start.position - (distance / dataline.Network.delay * size * direction / 2);
		GameObject new_block = Instantiate(block, starting_position, transform.rotation);

		//Makes the block go
		Vector3 velocity = direction.normalized * speed;
		new_block.GetComponent<Rigidbody>().velocity = velocity;

		//Makes the block appropriately skinny
		//new_block.transform.localScale = new Vector3(new_block.transform.localScale.x, new_block.transform.localScale.y, adjustment * 2);
		new_block.transform.localScale = new Vector3(new_block.transform.localScale.x, new_block.transform.localScale.y, (distance / dataline.Network.delay) * size);

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


		Destroy(new_block, dataline.Network.delay + size);
	}
	
	private void UnpackData(Data data)
	{
		RpcDataDownload(data.size, data.category);
	}

	[ClientRpc]
	private void RpcDataDownload(float size, string category)
	{
		//Math to make the next three things work
		float distance = Vector3.Distance(start.position, end.position);
		float speed = distance / dataline.Network.delay;

		Vector3 direction = (start.position - end.position).normalized;

		//Makes a new block behind the starting position with the same rotation as the parent object
		Vector3 starting_position = end.position - (distance / dataline.Network.delay * size * direction / 2);
		GameObject new_block = Instantiate(block, starting_position, transform.rotation);

		//Makes the block go
		Vector3 velocity = direction.normalized * speed;
		new_block.GetComponent<Rigidbody>().velocity = velocity;

		//Makes the block appropriately skinny
		new_block.transform.localScale = new Vector3(new_block.transform.localScale.x, new_block.transform.localScale.y, (distance / dataline.Network.delay) * size);

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


		Destroy(new_block, dataline.Network.delay + size);
	}
}
