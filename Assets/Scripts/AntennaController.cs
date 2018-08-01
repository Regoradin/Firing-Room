using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AntennaController : NetworkBehaviour, IIntTaskable, IVector3Taskable{

    private Network network;
    public AntennaManager manager;
    public BoolDisplay connected_display;   //if the index connected to an antenna
    public BoolDisplay linked_display;  //if a full path to ship is established
    public BoolDisplay antenna_linked_display; //if the selected antenna is connected to another antenna

    private Antenna connected_ant;

    private void Start()
    {
        network = GameObject.Find("Network").GetComponent<Network>();
    }

    public void IntTask(int index)
    {
        bool found = false;
        foreach(Antenna ant in manager.antennas)
        {
            if(ant.index == index)
            {
                connected_ant = ant;
                found = true;
            }
        }
        connected_display.state = found;
    }

    public void Vector3Task(Vector3 target)
    {
        if (connected_ant)
        {
            connected_ant.Target(target.x, target.y, target.z);
        }
    }

    private void Update()
    {
        if (network.delay == -1)
        {
            linked_display.state = false;
        }
        else
        {
            linked_display.state = true;
        }
        if (connected_ant != null && connected_ant.connected_ant != null)
        {
            antenna_linked_display.state = true;
        }
        else
        {
            antenna_linked_display.state = false;
        }
    }

}
